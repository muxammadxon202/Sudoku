using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        const int n = 3;
        const int sizeButton = 50;
        public int[,] map = new int[n * n, n * n];
        public Button[,] buttons = new Button[n * n, n * n];
        public Form1()
        {
            InitializeComponent();
            GenerateMap();
        }

        public void GenerateMap()
        {
            for(int i = 0; i < n * n; i++)
            {
                for(int j = 0; j < n * n; j++)
                {
                    map[i, j] = (i * n + i / n + j) % (n * n) + 1;
                    buttons[i, j] = new Button();
                }
            }
            //MatrixTransposition();
            //SwapRowsInBlock();
            //SwapColumnsInBlock();
            //SwapBlocksInRow();
            //SwapBlocksInColumn();
            Random r = new Random();
            for(int i = 0; i < 40; i++)
            {
                ShuffleMap(r.Next(0, 5));
            }
           
            CreateMap();
            HideCells();
        }

        public void HideCells()
        {
            int N = 40;
            Random r = new Random();
            while (N > 0)
            {
                for (int i = 0; i < n * n; i++)
                {
                    for (int j = 0; j < n * n; j++)
                    {
                        if (!string.IsNullOrEmpty(buttons[i, j].Text)){
                            int a = r.Next(0, 3);
                            buttons[i, j].Text = a == 0 ? "" : buttons[i, j].Text;
                            buttons[i, j].Enabled = a == 0 ? true : false;

