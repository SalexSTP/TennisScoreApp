using System;
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
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
        }

        public (string, int) FirstPlayer { get; set; }
        public (string, int) SecondPlayer { get; set; }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string firstPlayerName = FirstPlayerTextBox.Text.Trim();
            int firstPlayerPoints = (int)FirstPlayerPoints.Value;

            string secondPlayerName = SecondPlayerTextBox.Text.Trim();
            int secondPlayerPoints = (int)SecondPlayerPoints.Value;

            FirstPlayer = (firstPlayerName, firstPlayerPoints);
            SecondPlayer = (secondPlayerName, secondPlayerPoints);

            if (!CheckIfInputsAreValid())
            {
                ValidateChildren(ValidationConstraints.Enabled);
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private bool CheckIfInputsAreValid() =>
            !CheckIfPlayerNamesAreEmpty() &&
            !CheckIfPlayerNamesAreSame();

        private bool CheckIfPlayerNamesAreEmpty() =>
            string.IsNullOrEmpty(this.FirstPlayer.Item1)
            || string.IsNullOrEmpty(this.SecondPlayer.Item1);

        private bool CheckIfPlayerNamesAreSame() => this.FirstPlayer.Item1 == this.SecondPlayer.Item1;

        private void ValidatePlayerName(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrWhiteSpace(textBox.Text)) 
            {
                e.Cancel = true;
                textBox.Focus();
                ShowEmptyNameErrorMessage(textBox);
            }
            else
            {
                e.Cancel = false;
                RemoveErrorMessages(textBox);
                ShowErrorOnSameNames();
            }
        }

        private void ShowEmptyNameErrorMessage(TextBox textBox)
        {
            var errorText = "Player Name should not be left blank!";

            if (textBox == this.FirstPlayerTextBox)
            {
                this.FirstPlayerNameErrorProvider.SetError(textBox, errorText);
                this.FirstPlayerNameErrorLabel.Text = "First " + errorText;
            }
            else if (textBox == this.SecondPlayerTextBox)
            {
                this.SecondPlayerNameErrorProvider.SetError(textBox, errorText);
                this.SecondPlayerNameErrorLabel.Text = "Second " + errorText;
            }
        }

        private void RemoveErrorMessages(TextBox textBox)
        {
            if (textBox == this.FirstPlayerTextBox)
            {
                this.FirstPlayerNameErrorProvider.SetError(textBox, "");
                this.FirstPlayerNameErrorLabel.Text = string.Empty;
            }
            else if (textBox == this.SecondPlayerTextBox)
            {
                this.SecondPlayerNameErrorProvider.SetError(textBox, "");
                this.SecondPlayerNameErrorLabel.Text = string.Empty;
            }
        }
        
        private void ShowErrorOnSameNames()
        {
            if (CheckIfPlayerNamesAreSame())
            {
                this.SameNamesErrorLabel.Text = "First Player name should not be same as Second Player name!";
            }
            else
            {
                this.SameNamesErrorLabel.Text = string.Empty;
            }
        }
    }
}
