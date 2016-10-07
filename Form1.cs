using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SlimDX.XInput;

namespace KakiVibration {
    public partial class Form1 : Form {

        // コントローラ
        Controller con = new Controller(UserIndex.One);
        // 乳揺力
        Vibration vib = new Vibration();
        // 振動数0の乳揺力
        Vibration zeroVib = new Vibration();
        // 振動停止中か
        Boolean isVibration = false;

        public Form1() {
            InitializeComponent();
            zeroVib.LeftMotorSpeed = 0;
            zeroVib.RightMotorSpeed = 0;
            isVibration = con.IsConnected;
            updateStat();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void label8_Click(object sender, EventArgs e) {

        }

        /// <summary>
        /// 右モーター(高周波)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_Scroll(object sender, EventArgs e) {
            int val = trackBar2.Value;
            label2.Text = (val / 655.35).ToString("0.00");
            vib.RightMotorSpeed = (ushort)val;
            setVib(ref vib);
        }

        private void groupBox2_Enter(object sender, EventArgs e) {

        }

        /// <summary>
        /// 左モーター(低周波)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e) {
            int val = trackBar1.Value;
            label5.Text = (val / 655.35).ToString("0.00");
            vib.LeftMotorSpeed = (ushort)val;
            setVib(ref vib);
        }

        /// <summary>
        /// 再検出ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e) {
            updateStat();
        }

        /// <summary>
        /// ぶるぶるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            isVibration = true;
            setVib(ref vib);
        }

        /// <summary>
        /// ぶるぶるやめるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e) {
            isVibration = true;
            setVib(ref zeroVib);
            isVibration = false;
        }

        private void updateStat() {
            label8.Text = con.IsConnected ? "接続" : "未接続";
        }

        private void setVib(ref Vibration vib) {
            updateStat();
            if (con.IsConnected && isVibration) {
                con.SetVibration(vib);
            }
        }
    }
}
