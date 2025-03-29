﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TennisScoreApp
{
    public partial class PlayerInfo : Form
    {
        private string playerName;
        private Dictionary<(string, int), List<(string, int)>> games = new();
        private (string, int) currentPlayer = new();
        private (string, int) competitor = new();

        public PlayerInfo(string playerName, Dictionary<(string, int), List<(string, int)>> games)
        {
            InitializeComponent();

            this.games = games;
            this.playerName = playerName;

            this.PlayerNameLabel.Text = playerName;

            FillVictoriesAndLossesListViews();
        }

        private void FillVictoriesAndLossesListViews()
        {
            ClearListViews();

            foreach (var game in games)
            {
                string firstPlayerName = game.Key.Item1;
                int firstPlayerPoints = game.Key.Item2;

                foreach (var item in game.Value)
                {
                    string secondPlayerName = item.Item1;
                    int secondPlayerPoints = item.Item2;

                    (this.currentPlayer, this.competitor) =GetCurrentPlayerAndCompetitor((firstPlayerName, firstPlayerPoints), (secondPlayerName, secondPlayerPoints));

                    UpdateListView();
                }
            }
        }
        private void ClearListViews()
        {
            this.DrawListView.Items.Clear();
            this.LossesListView.Items.Clear();
            this.VictoriesListView.Items.Clear();
        }

        private ((string, int), (string, int)) GetCurrentPlayerAndCompetitor((string, int) firstPlayer, (string, int) secondPlayer)
        {
            if (firstPlayer.Item1 == playerName)
            {
                return (firstPlayer, secondPlayer);
            }

            return (secondPlayer, firstPlayer);
        }

        private void UpdateListView()
        {
            string competitorName = competitor.Item1;
            int currentPlayerPoints = currentPlayer.Item2;
            int competitorPoints = competitor.Item2;

            string score = $"{currentPlayerPoints} - {competitorPoints}";

            ListView currentListView = GetCurrentListView(currentPlayerPoints, competitorPoints);
            AddDataToListView(competitorName, score, currentListView);
        }

        private ListView GetCurrentListView(int currentPlayerPoints, int competitorPoints)
        {
            if (currentPlayerPoints > competitorPoints)
            {
                // Victories
                return this.VictoriesListView;
            }
            else if (currentPlayerPoints < competitorPoints)
            {
                // Losses
                return this.LossesListView;
            }

            // Draws
            return this.DrawListView;
        }

        private void AddDataToListView(string competitor, string score, ListView listView)
        {
            ListViewItem listViewItem = new ListViewItem();

            listViewItem.SubItems[0].Text = competitor;
            listViewItem.SubItems.Add(score);
            listView.Items.Add(listViewItem);
        }
    }
}
