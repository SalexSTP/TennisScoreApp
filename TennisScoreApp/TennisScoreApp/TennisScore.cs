using static System.Windows.Forms.ListViewItem;

namespace TennisScoreApp
{
    public partial class TennisScore : Form
    {
        private static Dictionary<string, int> playersWithPoints = new();

        private static Dictionary<(string, int), List<(string, int)>> games = new();

        private void OnLoad(object sender, EventArgs e)
        {
            FillRankingListView();
            FillLatestGamesListView();
        }

        public TennisScore()
        {
            InitializeComponent();
        }

        private void FillRankingListView()
        {
            this.RankingListView.Items.Clear();

            foreach (var player in playersWithPoints.OrderByDescending(x => x.Value))
            {
                string playerName = player.Key;
                string playerPoints = player.Value.ToString();

                ListViewItem rollInRankingListView = new();

                rollInRankingListView.SubItems[0].Text = playerName;
                rollInRankingListView.SubItems.Add(playerPoints);

                this.RankingListView.Items.Add(rollInRankingListView);
            }
        }

        private void ViewProfileButtonClick(object sender, EventArgs e)
        {
            ListViewItem selectedRow = this.RankingListView.SelectedItems[0];

            ListViewSubItem playerNameCell = selectedRow.SubItems[0];

            string playerName = playerNameCell.Text;

            using (PlayerInfo playerInfoForm = new PlayerInfo(playerName, GetPlayerGames(playerName)))
            {
                playerInfoForm.ShowDialog();
            }
        }

        private void FillLatestGamesListView()
        {
            this.LatestGamesListView.Items.Clear();

            foreach (var game in games.Reverse())
            {
                foreach (var item in game.Value)
                {
                    FillListView(game.Key, item);
                }
            }
        }

        private void FillListView((string, int) firstPlayer, (string, int) secondPlayer)
        {
            string winner = GetWinner(firstPlayer, secondPlayer);

            ListViewItem rollInLatestGamesListView = new ListViewItem();

            rollInLatestGamesListView.SubItems[0].Text = firstPlayer.Item1;
            rollInLatestGamesListView.SubItems.Add(secondPlayer.Item1);
            rollInLatestGamesListView.SubItems.Add(winner);
            rollInLatestGamesListView.SubItems.Add($"{firstPlayer.Item2} - {secondPlayer.Item2}");

            this.LatestGamesListView.Items.Add(rollInLatestGamesListView);
        }

        private string GetWinner((string, int) firstPlayer, (string, int) secondPlayer)
        {
            if (firstPlayer.Item2 > secondPlayer.Item2)
            {
                return firstPlayer.Item1;
            }
            else if (firstPlayer.Item2 < secondPlayer.Item2)
            {
                return secondPlayer.Item1;
            }

            return "Draw";
        }

        private void AddNewGameButton_Click(object sender, EventArgs e)
        {
            using (NewGame newGameForm = new NewGame())
            {
                if (newGameForm.ShowDialog() == DialogResult.OK)
                {
                    AddNewGame(newGameForm.FirstPlayer, newGameForm.SecondPlayer);
                }
            }
        }

        private void AddNewGame((string, int) firstPlayer, (string, int) secondPlayer)
        {
            FillGamesData(firstPlayer, secondPlayer);

            FillPlayerWithPoints(firstPlayer);
            FillPlayerWithPoints(secondPlayer);

            FillRankingListView();
            FillLatestGamesListView();
        }

        private void FillGamesData((string, int) firstPlayer, (string, int) secondPlayer)
        {
            if (games.ContainsKey(firstPlayer))
            {
                games[firstPlayer].Add(secondPlayer);
            }
            else if (games.ContainsKey(secondPlayer))
            {
                games[secondPlayer].Add(firstPlayer);
            }
            else
            {
                games.Add(firstPlayer, new List<(string, int)> { secondPlayer });
            }
        }

        private void FillPlayerWithPoints((string, int) player)
        {
            if (playersWithPoints.ContainsKey(player.Item1))
            {
                playersWithPoints[player.Item1] += player.Item2;
            }
            else
            {
                playersWithPoints.Add(player.Item1, player.Item2);
            }
        }

        private Dictionary<(string, int), List<(string, int)>> GetPlayerGames(string playerName)
            => games.Where(x => x.Key.Item1 == playerName
            || x.Value.Any(y => y.Item1 == playerName))
            .ToDictionary(x => x.Key, x => x.Value
            .Where(y => y.Item1 == playerName 
                || x.Key.Item1 == playerName).ToList());
    }
}