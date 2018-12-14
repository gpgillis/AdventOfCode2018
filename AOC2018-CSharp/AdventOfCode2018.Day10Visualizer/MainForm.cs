using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdventOfCode2018.Day10;


namespace AdventOfCode2018.Day10Visualizer
{
    public partial class MainForm : Form
    {
        private BackgroundWorker worker;
        private int _delay = 1000;
        private int _doGraphic = 10;
        private int _normalizer = 600;

        private int _elapsedSeconds = 0;

        private AdventOfCode2018.Day10.Day10Solver _solver;

        public MainForm()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;

            worker.RunWorkerCompleted += workerComplete;
            worker.DoWork += worker_DoWork;

            _delayTextBox.Text = _delay.ToString();
            _doGraphicTextBox.Text = _doGraphic.ToString();
            _normalizerTextBox.Text = _normalizer.ToString();
            LoadSolver();
        }

        private void LoadSolver()
        {
            if (_solver == null)
                _solver = new AdventOfCode2018.Day10.Day10Solver();

            _solver.Reset();
            _solver.Normalizer = new Point(_normalizer, _normalizer);
            //_solver.LoadTestData();
            _solver.LoadProductionData();
            _elapsedSeconds = 0;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var g = this._graphicsPanel.CreateGraphics();
            var penline = new Pen(Color.White, 1);

            int doGraphic = 0;

            while (worker.CancellationPending == false)
            {
                _elapsedSeconds++;
                var data = _solver.SolveNext().ToList();

                if (data[0].X < 600 || data[0].Y < 600)
                    doGraphic = 0;
                    

                if (doGraphic == 0)
                {
                    doGraphic = _doGraphic;

                    g.Clear(Color.Black);

                    foreach (var point in data)
                    {
                        if (worker.CancellationPending)
                            return;

                        g.DrawRectangle(penline, point.X, point.Y, 1, 1);
                    }
                }
                doGraphic--;

                System.Threading.Thread.Sleep(_delay);
            }
        }

        private void workerComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = "Complete";
            _elapsedSecondsLabel.Text = _elapsedSeconds.ToString();
        }

        private void _pauseButton_Click(object sender, EventArgs e)
        {
            this.Text = "Pause";
            worker.CancelAsync();
        }

        private void _runButton_Click(object sender, EventArgs e)
        {
            this.Text = "Running ... ";
            _elapsedSecondsLabel.Text = "Elapsed";
            worker.RunWorkerAsync();
        }

        private void _delayTextBox_TextChanged(object sender, EventArgs e)
        {
            int delay;
            if (int.TryParse(_delayTextBox.Text, out delay))
            {
                _delay = delay;
            }
        }

        private void _doGraphicTextBox_TextChanged(object sender, EventArgs e)
        {
            int doGraphic;
            if (int.TryParse(_doGraphicTextBox.Text, out doGraphic))
            {
                _doGraphic = doGraphic;
            }
        }

        private void _normalizerTextBox_TextChanged(object sender, EventArgs e)
        {
            int normalizer;
            if (int.TryParse(_normalizerTextBox.Text, out normalizer))
            {
                _normalizer = normalizer;
            }
        }

        private void _reloadButton_Click(object sender, EventArgs e)
        {
            LoadSolver();
        }
    }
}
