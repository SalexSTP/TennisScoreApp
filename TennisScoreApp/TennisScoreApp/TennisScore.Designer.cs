
using static System.Windows.Forms.ListViewItem;

namespace TennisScoreApp
{
    partial class TennisScore
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Title = new Label();
            RankingLable = new Label();
            LatestGamesLable = new Label();
            RankingListView = new ListView();
            PlayerName = new ColumnHeader();
            Score = new ColumnHeader();
            LatestGamesListView = new ListView();
            FirstPlayer = new ColumnHeader();
            SecondPlayer = new ColumnHeader();
            Winner = new ColumnHeader();
            WinnerScore = new ColumnHeader();
            AddNewGameButton = new Button();
            PlayersSuggestionLable = new Label();
            SuspendLayout();
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top;
            Title.AutoSize = true;
            Title.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            Title.Location = new Point(317, 9);
            Title.Name = "Title";
            Title.Size = new Size(212, 47);
            Title.TabIndex = 0;
            Title.Text = "Tennis Score";
            // 
            // RankingLable
            // 
            RankingLable.AutoSize = true;
            RankingLable.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            RankingLable.Location = new Point(56, 62);
            RankingLable.Name = "RankingLable";
            RankingLable.Size = new Size(80, 25);
            RankingLable.TabIndex = 1;
            RankingLable.Text = "Ranking";
            // 
            // LatestGamesLable
            // 
            LatestGamesLable.AutoSize = true;
            LatestGamesLable.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            LatestGamesLable.Location = new Point(56, 270);
            LatestGamesLable.Name = "LatestGamesLable";
            LatestGamesLable.Size = new Size(123, 25);
            LatestGamesLable.TabIndex = 2;
            LatestGamesLable.Text = "Latest Games";
            // 
            // RankingListView
            // 
            RankingListView.BackColor = Color.MistyRose;
            RankingListView.Columns.AddRange(new ColumnHeader[] { PlayerName, Score });
            RankingListView.Click += ViewProfileButtonClick;
            RankingListView.LabelEdit = true;
            RankingListView.Location = new Point(56, 90);
            RankingListView.Name = "RankingListView";
            RankingListView.Size = new Size(694, 121);
            RankingListView.TabIndex = 3;
            RankingListView.UseCompatibleStateImageBehavior = false;
            RankingListView.View = View.Details;
            // 
            // PlayerName
            // 
            PlayerName.Text = "Player Name";
            PlayerName.Width = 500;
            // 
            // Score
            // 
            Score.Text = "Score";
            Score.Width = 190;
            // 
            // LatestGamesListView
            // 
            LatestGamesListView.BackColor = Color.MistyRose;
            LatestGamesListView.Columns.AddRange(new ColumnHeader[] { FirstPlayer, SecondPlayer, Winner, WinnerScore });
            LatestGamesListView.Location = new Point(56, 298);
            LatestGamesListView.Name = "LatestGamesListView";
            LatestGamesListView.Size = new Size(694, 121);
            LatestGamesListView.TabIndex = 4;
            LatestGamesListView.UseCompatibleStateImageBehavior = false;
            LatestGamesListView.View = View.Details;
            // 
            // FirstPlayer
            // 
            FirstPlayer.Text = "FirstPlayer";
            FirstPlayer.Width = 200;
            // 
            // SecondPlayer
            // 
            SecondPlayer.Text = "Second Player";
            SecondPlayer.Width = 200;
            // 
            // Winner
            // 
            Winner.Text = "Winner";
            Winner.Width = 200;
            // 
            // WinnerScore
            // 
            WinnerScore.Text = "Score";
            WinnerScore.Width = 90;
            // 
            // AddNewGameButton
            // 
            AddNewGameButton.BackColor = SystemColors.InactiveCaption;
            AddNewGameButton.Location = new Point(597, 253);
            AddNewGameButton.Name = "AddNewGameButton";
            AddNewGameButton.Size = new Size(142, 33);
            AddNewGameButton.TabIndex = 5;
            AddNewGameButton.Text = "Add New Game";
            AddNewGameButton.UseVisualStyleBackColor = false;
            AddNewGameButton.Click += AddNewGameButton_Click;
            // 
            // PlayersSuggestionLable
            // 
            PlayersSuggestionLable.AutoSize = true;
            PlayersSuggestionLable.Location = new Point(56, 214);
            PlayersSuggestionLable.Name = "PlayersSuggestionLable";
            PlayersSuggestionLable.Size = new Size(375, 15);
            PlayersSuggestionLable.TabIndex = 6;
            PlayersSuggestionLable.Text = "*click on a players name to see more information about their matches";
            // 
            // TennisScore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(PlayersSuggestionLable);
            Controls.Add(AddNewGameButton);
            Controls.Add(LatestGamesListView);
            Controls.Add(RankingListView);
            Controls.Add(LatestGamesLable);
            Controls.Add(RankingLable);
            Controls.Add(Title);
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "TennisScore";
            Text = "Score";
            Load += OnLoad;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Title;
        private Label RankingLable;
        private Label LatestGamesLable;
        private ListView RankingListView;
        private ListView LatestGamesListView;
        private ColumnHeader PlayerName;
        private ColumnHeader Score;
        private ColumnHeader FirstPlayer;
        private ColumnHeader SecondPlayer;
        private ColumnHeader Winner;
        private ColumnHeader WinnerScore;
        private Button AddNewGameButton;
        private Label PlayersSuggestionLable;
    }
}
