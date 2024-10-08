﻿
namespace RPSGame;

public partial class MainPage : ContentPage
{
    string userchoice; // variables choice of system and user 
    string systemchoice; 

    string rock = "rock";
    string paper = "paper";
    string scissor = "scissor"; // variables of rock,paper and scissors to help in comparision for determining winner
    
    int playersScore;
    int systemScore;

    int systemNumber; // variable to store random number which is used in generating system choice
    Random randomGen = new Random();
    int roundNumber=0; 
    
    public MainPage()
    {
        InitializeComponent();
    }
    /// <summary>
    /// reets the player and system attributes. Can be accessed only when round is over
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    
    private void OnClick_NewGameButton(object sender, EventArgs e) //sets various attributes of Image, ImageButton and Label
    {
        playersScore = 0;
        systemScore = 0;
        roundNumber = 0;
        Label2.Text = $"Player score: {playersScore}";
        Label3.Text = $"System score: {systemScore}";
        Label4.Text = "Select your choice";
        UserQuestionMark.Source = "question_mark.png";
        SystemQuestionMark.Source = "question_mark.png";
        NewGameButton.IsVisible = false;
        RockButton.IsEnabled=true;
        PaperButton.IsEnabled=true;
        ScissorsButton.IsEnabled=true;
        NewGameButton.IsEnabled=false;
        Label4.IsVisible=true;
        UpdateRound();        
    }
    /// <summary>
    /// returns true if 3 rounds are not completed
    /// </summary>
    /// <returns></returns>
    private bool VerifyRound() // returns true if 3 rounds are over 
    {
        roundNumber++;
        if (roundNumber > 3 || playersScore == 2 || systemScore == 2)
        {
            return false;
        }
        return true;
    }
   
    /// <summary>
    /// updates round number after round is played
    /// </summary>
    private void UpdateRound() // verifies if 3 rounds are completed. If completed then displays winner
    {
        bool round = VerifyRound();
        if (round)
        {
             Rounds.Text = $"ROUND {roundNumber}";
        }
        else
        {
            ShowWinner();
        }
    }

    /// <summary>
    /// Displays the winner resets NewGameButton and RPS buttons and roundNumber
    /// </summary>
    private void ShowWinner() 
    {
        Rounds.Text = "GAME OVER";
        if (playersScore == systemScore)
        {
            //Label4.Text = "Tie";
            DisplayAlert("GAME OVER", "TIE", "Ok");
        }
        else if (playersScore > systemScore || playersScore == 2)
        {
            DisplayAlert("GAME OVER", "YOU WIN", "Ok");
        }
        else if(systemScore > playersScore || systemScore == 2)
        {
            DisplayAlert("GAME OVER", "YOU LOSE", "Ok");
        }

        NewGameButton.IsEnabled = true;
        NewGameButton.IsVisible = true;
        PaperButton.IsEnabled = false;
        RockButton.IsEnabled = false;
        ScissorsButton.IsEnabled = false;
        roundNumber = 0;
    }
   
    /// <summary>
    /// determines the winner by comparing choices
    /// </summary>
    
    private void DetermineWinner() 
    {
        if(userchoice == systemchoice)
        {
            //Does nothing
        }
        else if((userchoice == rock && systemchoice == scissor) || 
                (userchoice == paper && systemchoice == rock) ||
                (userchoice == scissor && systemchoice ==  paper))
        {
            playersScore++;
            Label2.Text = $"Player Score: {playersScore}";

        }
        else
        {
            systemScore++;
            Label3.Text = $"System Score: {systemScore}";
        }

        UpdateRound(); // Updates round after determining winner
    }
    /// <summary>
    /// generates corresponding image and assigns value to userchoice
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    
    private void OnClick_PaperButton(object sender, EventArgs e)
    {
		UserQuestionMark.Source = ImageSource.FromFile("paper.png");
        userchoice = "paper";
        GenerateSystemChoice();
        DetermineWinner();
    }
    /// <summary>
    /// generates corresponding image and assigns value to userchoice
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    
    private void OnClick_RockButton(object sender, EventArgs e)
    {
        UserQuestionMark.Source = ImageSource.FromFile("rock.png");
        userchoice = "rock";
        GenerateSystemChoice();
        DetermineWinner();
    }
    /// <summary>
    /// generates corresponding image and assigns value to userchoice
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    
    private void OnClick_ScissorButton(object sender, EventArgs e)
    {
        UserQuestionMark.Source = ImageSource.FromFile("scissors.png");
        userchoice = "scissor";
        GenerateSystemChoice();
        DetermineWinner();
    }
    /// <summary>
    /// generates system choice randomly using random function
    /// </summary>
    
    private void GenerateSystemChoice() 
    {   /* 1: Rock
         * 2: Paper
         * 3: Scissor
         */
        systemNumber = randomGen.Next(1, 4);
        if (systemNumber == 1)
        {
            SystemQuestionMark.Source = ImageSource.FromFile("rock.png");
            systemchoice = "rock";
        }
        else if(systemNumber == 2)
        {
            SystemQuestionMark.Source = ImageSource.FromFile("paper.png");
            systemchoice = "paper";
        }
        else if(systemNumber == 3)
        {
            SystemQuestionMark.Source = ImageSource.FromFile("scissors.png");
            systemchoice = "scissor";
        }
    }
}

