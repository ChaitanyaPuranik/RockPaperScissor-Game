
namespace RPSGame;

public partial class MainPage : ContentPage
{
    string userchoice;
    string systemchoice;
    string rock = "rock";
    string paper = "paper";
    string scissor = "scissor";
    int playersScore;
    int systemScore;

    int systemNumber;
    Random randomGen = new Random();
    int roundNumber=0; 
    
    public MainPage()
    {
        InitializeComponent();
    }
    
    private void OnClick_NewGameButton(object sender, EventArgs e)
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

    private bool VerifyRound()
    {
        
        roundNumber++;
        if (roundNumber > 3)
        {
            return false;
        }
        return true;
    }
   
    private void UpdateRound()
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
    private void ShowWinner()
    {
        Rounds.Text = "GAME OVER";
        if (playersScore == systemScore)
        {
            Label4.Text = "Tie";
        }
        else if (playersScore > systemScore)
        {
            Label4.Text = "You Win";
        }
        else
        {
            Label4.Text = "You lose";
        }

        NewGameButton.IsEnabled = true;
        NewGameButton.IsVisible = true;
        PaperButton.IsEnabled = false;
        RockButton.IsEnabled = false;
        ScissorsButton.IsEnabled = false;
        roundNumber = 0;
    }
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
            playersScore += 10;
            Label2.Text = $"Player Score: {playersScore}";

        }
        else
        {
            systemScore += 10;
            Label3.Text = $"System Score: {systemScore}";
        }

        UpdateRound();
    }
    
    private void OnClick_PaperButton(object sender, EventArgs e)
    {
		UserQuestionMark.Source = ImageSource.FromFile("paper.png");
        userchoice = "paper";
        GenerateSystemChoice();
        DetermineWinner();
    }

    private void OnClick_RockButton(object sender, EventArgs e)
    {
        UserQuestionMark.Source = ImageSource.FromFile("rock.png");
        userchoice = "rock";
        GenerateSystemChoice();
        DetermineWinner();
    }

    private void OnClick_ScissorButton(object sender, EventArgs e)
    {
        UserQuestionMark.Source = ImageSource.FromFile("scissors.png");
        userchoice = "scissor";
        GenerateSystemChoice();
        DetermineWinner();
    }
    
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

