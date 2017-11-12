using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameronJones_GADE_A1
{
    public partial class Form1 : Form
    {
        GameEngine game = new GameEngine();
        MeleeUnit m = new MeleeUnit(0, 0, "Hero", 'M');
        RangedUnit r = new RangedUnit(0, 0, "Hero", 'R');
        Unit[] tempArrUnit;
        
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            game.Timer = 0;
            timerGameTick1.Interval = 1000;
            timerGameTick1.Start();
            tempArrUnit = game.Map.PopulateBattlefield();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
          
        }

        private void timerGameTick1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = game.Timer.ToString();
            game.PlayGame();
           
            lblMap.Text = String.Empty;
            lblMap.Text = game.MapString1;
           
        }

    

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbUnit.Text == "Melee Unit")
            {
                lblStats.Text = m.ToString();
            }
            if (cmbUnit.Text == "Ranged Unit")
            {
                lblStats.Text = r.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            m.SaveUnit(game.Map.ArrUnit);
            r.SaveUnit(game.Map.ArrUnit);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            m.ReadUnit();
            r.ReadUnit();
        }
    }
}
