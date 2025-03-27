using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace _485扫描
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private byte count = 0;
        public Form1()
        {
            InitializeComponent();
            baudRateComboBox.SelectedIndex = 3;
            timeInput.Value = 80;
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
                        //MessageBox.Show("串口连接成功！");
                        openButton.Text = "关闭";
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
                staetTxt.AppendText(BitConverter.ToString(buffer).Replace("-", " ") + Environment.NewLine); // 显示到文本框 
            }));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames(); // 获取所有可用串口
            string com = portComboBox.Text;
            portComboBox.Items.Clear();//清除数据
            if(ports!=null&&ports.Length > 0)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == false && isSerialPortOpen())
            {
                count = 1;
                timer2.Interval = (int)timeInput.Value;
                //staetTxt.AppendText((int)timeInput.Value + Environment.NewLine); // 显示到文本框
                timer2.Enabled = true;
                label5.Text = "开始扫描";
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled == true && isSerialPortOpen())
            {
                //staetTxt.AppendText((int)timeInput.Value + Environment.NewLine); // 显示到文本框
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
            try
            {
                serialPort.Write(frame, 0, frame.Length);
            }

            catch (Exception ex)
            {
                //MessageBox.Show($"串口异常：{ex.Message}");
                serialPortClose();

            }
            label5.Text = "扫描地址：" + count;
            //staetTxt.AppendText(BitConverter.ToString(frame).Replace("-", " ")); // 显示到文本框 
            if (count >= 255)
            {
                timer2.Enabled = false;
            }
            else count++;
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
