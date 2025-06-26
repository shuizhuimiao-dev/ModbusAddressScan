using System;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.Sockets; // 添加命名空间
using System.Threading;   // 如需异步可用
using System.Net; // 需在文件顶部添加
using System.Net.NetworkInformation;
namespace _485扫描
{
    public partial class Form1 : Form
    {
        // 在 Form1 类中添加字段
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private TcpListener tcpListener;
        private Thread listenerThread;
        private bool isServerRunning = false;
        private Thread clientReceiveThread;
        private NetworkStream stream;
        private int clientsNumber = 0;// 客户端数量
        private SerialPort serialPort;
        private byte count = 0;
        public Form1()
        {
            InitializeComponent();
            baudRateComboBox.SelectedIndex = 3;
            agreementComboBox.SelectedIndex = 0; // 默认选择TCP Server
            timeInput.Value = 80;
            portComboBox_MouseDown(null, null);
        }
        private bool isSerialPortOpen()
        {
            return !(serialPort == null || !serialPort.IsOpen);
        }
        private void serialPortClose()//关闭串口
        {
            serialPort.Close(); // 关闭串口
            serialPort.Dispose();
            serialPort = null;
            //MessageBox.Show("串口已关闭！");
            openButton.Text = "打开";
            label5.Text = "停止扫描";
            timer2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openButton.Text == "打开")
            {
                try
                {
                    if (!isSerialPortOpen())
                    {
                        if (portComboBox.SelectedIndex == -1||portComboBox.SelectedItem.ToString() == null)
                        {
                            throw new InvalidOperationException("没有找到串口！！");
                        }
                        serialPort = new SerialPort(portComboBox.SelectedItem.ToString())
                        {
                            BaudRate = Int32.Parse(baudRateComboBox.Text), // 设置波特率
                            DataBits = 8, // 数据位
                            StopBits = StopBits.One, // 停止位
                            Parity = Parity.None, // 校验位
                            Handshake = Handshake.None // 流控制
                        };

                        serialPort.DataReceived += SerialPort_DataReceived; // 绑定接收事件
                        serialPort.Open(); // 打开串口
                        openButton.Text = "关闭";
                        tabControl.TabPages[1].Enabled = false;
                        portComboBox.Enabled = false;
                        baudRateComboBox.Enabled= false;
                        logLabel.Text= "串口已打开！";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"连接失败：{ex.Message}");
                }
            }
            else//关闭串口
            {
                try
                {
                    if (serialPort != null)
                    {
                        serialPortClose();
                        tabControl.TabPages[1].Enabled = true;
                        portComboBox.Enabled = true;
                        baudRateComboBox.Enabled = true;
                        logLabel.Text = "串口已关闭！"; // 更新日志标签
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"关闭失败：{ex.Message}");
                }
            }
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytesToRead = serialPort.BytesToRead;
            byte[] buffer = new byte[bytesToRead];
            serialPort.Read(buffer, 0, bytesToRead);
            Invoke(new Action(() =>
            {
                staetTxt.AppendText(BitConverter.ToString(buffer).Replace("-", " ")); // 显示到文本框 
            }));
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true) return;
            if (isSerialPortOpen()|| isServerRunning)
            {
                if (isServerRunning&&agreementComboBox.Text == "TCP Server"&& clientsNumber==0)
                {
                    logLabel.Text = "当前无客户端连接！"; // 更新日志标签
                    return;
                }
                count = 1;
                timer2.Interval = (int)timeInput.Value;
                timer2.Enabled = true;
                label5.Text = "开始扫描";
            } 
            else
            {
                logLabel.Text = "请先打开串口或网络连接！"; // 更新日志标签
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true && (isSerialPortOpen() || isServerRunning))
            {
                timer2.Enabled = false;
                label5.Text = "停止扫描";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            staetTxt.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            byte[] frame = new byte[8];
            UInt16 reg = (UInt16)regInput.Value;
            frame[0] = count;
            frame[1] = 0x03;
            frame[2] = (byte)(reg >> 8);
            frame[3] = (byte)(reg & 0xff);
            frame[5] = 1;
            byte[] bytes = new byte[6];
            Array.Copy(frame, 0, bytes, 0, bytes.Length);
            byte[] crc = ModbusUtils.CalculateCRC(bytes);
            frame[6] = crc[0];
            frame[7] = crc[1];
            if (isSerialPortOpen()) // 检查串口是否打开
            {
                try
                {
                    serialPort.Write(frame, 0, frame.Length);
                }

                catch (Exception ex)
                {
                    serialPortClose();
                    logLabel.Text = "串口异常关闭！"; // 更新日志标签
                    staetTxt.AppendText(Environment.NewLine + "串口异常关闭！" + ex.Message + Environment.NewLine);
                    timer2.Enabled = false;
                    return;

                }
            }
            else if(listenerThread!=null&&isServerRunning)
            {
                try
                {
                    stream.Write(frame, 0, frame.Length);
                }
                catch (Exception ex)
                {
                    networkStop();
                    logLabel.Text = "网络异常关闭！"; // 更新日志标签
                    staetTxt.AppendText(Environment.NewLine + "网络异常关闭！" + ex.Message + Environment.NewLine);
                    timer2.Enabled = false;
                    return;
                }
            }

            label5.Text = "扫描地址：" + count;
            //获取staetTxt最后一行的数据
            if (staetTxt.Lines.Length > 0)
            {
                string lastLine = staetTxt.Lines[staetTxt.Lines.Length - 1];
                if (lastLine.Length > 0)
                {
                    //将lastLine的第一个16进制数转换为byte
                    byte firstByte = Convert.ToByte(lastLine.Substring(0, 2), 16);
                    staetTxt.AppendText("\t地址："+ firstByte+ Environment.NewLine); // 显示到文本框 
                }
            }
            if (count >= 255)
            {
                timer2.Enabled = false;
            }
            else count++;
        }

        private void portComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); // 获取所有可用串口
            string com = portComboBox.Text;
            portComboBox.Items.Clear();//清除数据
            if (ports != null && ports.Length > 0)
            {
                foreach (string port in ports)
                {
                    portComboBox.Items.Add(port); // 添加到下拉列表
                }
                int index = portComboBox.Items.IndexOf(com);
                if (index != -1)
                {
                    portComboBox.SelectedIndex = index;
                }
                else if (baudRateComboBox.TabIndex != -1)
                {
                    portComboBox.SelectedIndex = 0;
                }
            }
        }
        private string GetLocalIPv4()
        {
            string localIP = "";
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
        //判断输入ip是否是本机ip
        public  bool IsLocalIpAddressAdvanced(string ipAddress)
        {
            if(ipAddress == null || ipAddress.Trim() == "")
            {
                return false;
            }
            try
            {
                if (!IPAddress.TryParse(ipAddress, out IPAddress inputIp))
                {
                    return false;
                }

                // 检查环回地址
                if (IPAddress.IsLoopback(inputIp))
                {
                    return true;
                }

                // 获取所有网络接口
                NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface network in networkInterfaces)
                {
                    // 只检查运行中的接口
                    if (network.OperationalStatus != OperationalStatus.Up)
                        continue;

                    IPInterfaceProperties properties = network.GetIPProperties();

                    // 检查单播地址
                    foreach (UnicastIPAddressInformation ip in properties.UnicastAddresses)
                    {
                        if (ip.Address.Equals(inputIp))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
        private void StartTcpServer(String ip,int port)
        {
            IPAddress localAddr = IPAddress.Parse(ip); // 将字符串 IP 转换为 IPAddress
            tcpListener = new TcpListener(localAddr, port); // 使用 IPAddress 对象

            tcpListener.Start();
            isServerRunning = true;
            listenerThread = new Thread(ListenForClients);
            listenerThread.IsBackground = true;
            listenerThread.Start();
            logLabel.Text = "TCP服务端已启动";
        }

        private void StopTcpServer()
        {
            isServerRunning = false;
            tcpListener?.Stop();
            listenerThread?.Join();
            listenerThread=null;
            logLabel.Text = "TCP服务端已停止";
            clientsNumber = 0;
        }
        private void ListenForClients()
        {
            try
            {
                while (isServerRunning)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Thread clientThread = new Thread(HandleClientComm);
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                    Invoke(new Action(() =>
                    {
                        clientsNumber++;
                        logLabel.Text = $"新客户端连接，当前连接数: {clientsNumber}";
                    })); // 更新UI
                }
            }
            catch { }
        }
        //接受客户端通信
        private void HandleClientComm(object clientObj)
        {
            TcpClient client = (TcpClient)clientObj;
            stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;
            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string received = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Invoke(new Action(() =>
                    {
                        byte[] hex = new byte[bytesRead];
                        Array.Copy(buffer, hex, bytesRead); // 复制接收到的字节到新数组
                        staetTxt.AppendText(BitConverter.ToString(hex).Replace("-", " ")); // 显示到文本框
                        //staetTxt.AppendText("收到客户端: " + received + Environment.NewLine);
                    }));
                    // 可在此处回发数据
                    // stream.Write(buffer, 0, bytesRead);
                }
            }
            catch { }
            finally
            {
                stream.Close();
                client.Close();
            }
        }
        private void networkStartup(string serverIp,int serverPort)
        {
            if (agreementComboBox.Text == "TCP Server")
            {
                if (!IsLocalIpAddressAdvanced(serverIp))
                {
                    logLabel.Text = "输入地址不是本机IP！"; // 更新日志标签
                    return;
                }
                int port = (int)tcpPortNum.Value;
                StartTcpServer(serverIp, port);
                logLabel.Text = "服务端已打开";
            }
            else
            {
                try
                {
                    tcpClient = new TcpClient();
                    tcpClient.Connect(serverIp, serverPort); // 连接服务器
                    networkStream = tcpClient.GetStream();
                    listenerThread = new Thread(HandleClientComm);
                    listenerThread.Start(tcpClient);

                    logLabel.Text = "TCP连接成功！";
                }
                catch (Exception ex)
                {
                    logLabel.Text = "TCP连接异常: " + ex.Message;
                    return;
                }

            }
            networkButton.Text = "断开";
            agreementComboBox.Enabled = false;
            networkTextBox.Enabled = false;
            tcpPortNum.Enabled = false;
            isServerRunning = true;
            // 禁用某个选项卡（视觉上变灰且不可点击）
            tabControl.TabPages[0].Enabled = false;
        }
        private void networkStop()
        {
            if (agreementComboBox.Text == "TCP Server")
            {
                StopTcpServer();
                logLabel.Text = "服务端已关闭";
            }
            else
            {
                if (tcpClient != null)
                {
                    try
                    {
                        networkStream.Close();
                        tcpClient.Close();
                    }
                    catch
                    {
                        logLabel.Text = "断开失败";
                    }

                    tcpClient = null;
                    logLabel.Text = "TCP连接已断开！";
                    listenerThread= null;
                }
            }
            networkButton.Text = "连接";
            agreementComboBox.Enabled = true;
            networkTextBox.Enabled = true;
            tcpPortNum.Enabled = true;
            isServerRunning = false;
            // 禁用某个选项卡（视觉上变灰且不可点击）
            tabControl.TabPages[0].Enabled = true;
        }
        //网络连接的开始按钮
        private void networkButton_Click(object sender, EventArgs e)
        {
            string serverIp = networkTextBox.Text; // 服务器IP，可根据需要修改
            int serverPort = (int)tcpPortNum.Value;          // 端口号，可根据需要修改
            if (serverIp=="")
            {
                logLabel.Text = "请输入服务器IP地址！";
                return;
            }
            if (networkButton.Text== "连接")
            {

                networkStartup(serverIp,serverPort);
            }
            else
            {
                networkStop();
                timer2.Enabled = false;
                label5.Text = "停止扫描";
            }
        }



        private void agreementComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (agreementComboBox.Text == "TCP Server")
            {
                //获取本机ip地址
                networkTextBox.Text = GetLocalIPv4();
                
            }
            
        } 
    }
}
public static class ModbusUtils
{
    // CRC16 计算
    public static byte[] CalculateCRC(byte[] data)
    {
        ushort crc = 0xFFFF;

        foreach (byte b in data)
        {
            crc ^= b;

            for (int i = 0; i < 8; i++)
            {
                if ((crc & 0x0001) != 0)
                {
                    crc >>= 1;
                    crc ^= 0xA001;
                }
                else
                {
                    crc >>= 1;
                }
            }
        }

        return new byte[] { (byte)(crc & 0xFF), (byte)((crc >> 8) & 0xFF) }; // 返回低字节在前
    }
}
