using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

namespace Assignment.ViewModel
{
    public class GameViewModel : BaseViewModel
    {
        bool GameOver { get; set; }

        public string[,] CurrentGame { get; set; }
        
        public string GameResult { get; set; }
        public string GameResultImage { get; set; }
        bool HumanPlayer { get; set; } = true;

        bool gameResultVisible = false;

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }
        public bool GameResultVisible
        {
            get { return gameResultVisible; }
            set
            {
                gameResultVisible = value;
                OnPropertyChanged(nameof(GameResultVisible));
            }
        }
        bool gameResultImageVisible = false;
        public bool GameResultImageVisible
        {
            get { return gameResultImageVisible; }
            set
            {
                gameResultImageVisible = value;
                OnPropertyChanged(nameof(GameResultImageVisible));
            }
        }
        //  bool PlayAgainVisible { get; set; } = false;
        bool playAgainVisible = false;
        public bool PlayAgainVisible
        {
            get { return playAgainVisible; }
            set
            {
                playAgainVisible = value;
                OnPropertyChanged(nameof(PlayAgainVisible));
            }
        }

        public int Moves { get; set; } = 0;
        int HumanMoves { get; set; } = 0;
        int AIMoves { get; set; } = 0;

        public GameViewModel(Page page) : base(page)
        {
            CurrentGame = new string[3, 3];
            GameOver = false;
            ShowResult(false);
        }
        
            string play0 = string.Empty;
            public string Play0
            {
                get{ return play0; }
                set{
                    play0 = value;
                    OnPropertyChanged(nameof(Play0));
                   }
            }
            string play1 = string.Empty;
            public string Play1
            {
                get { return play1; }
                set
                    {   
                    play1 = value;
                    OnPropertyChanged(nameof(Play1));
                    }
            }
            string play2 = string.Empty;
            public string Play2
             {
                  get { return play2; }
                  set
                      {
                    play2 = value;
                    OnPropertyChanged(nameof(Play2));
                      }
             }
             string play3 = string.Empty;
             public string Play3
             {
                   get { return play3; }
                   set
                       {
                    play3 = value;
                    OnPropertyChanged(nameof(Play3));
                       }
             }
             string play4 = string.Empty;
             public string Play4
             {
                   get { return play4; }
                   set
                       {
                    play4 = value;
                    OnPropertyChanged(nameof(Play4));
                       }
             }
             string play5 = string.Empty;
             public string Play5
             {
                   get { return play5; }
                   set
                       {
                    play5 = value;
                    OnPropertyChanged(nameof(Play5));
                       }
             }
             string play6 = string.Empty;
             public string Play6
             {
                   get { return play6; }
                   set
                       {
                    play6 = value;
                    OnPropertyChanged(nameof(Play6));
                       }
             }
             string play7 = string.Empty;
            public string Play7
             {
                   get { return play7; }
                   set
                       {
                    play7 = value;
                    OnPropertyChanged(nameof(Play7));
                       }
                    }
             string play8 = string.Empty;
            public string Play8
             {
                  get { return play8; }
                  set
                      {
               
                    play8 =value;
                    OnPropertyChanged(nameof(Play8));
                      }
             }



        Command doneGameCommand;
        public Command DoneGameCommand
        {
            get
            {
                return doneGameCommand ??
                  (doneGameCommand = new Command(async () =>
                  {
                      //check if game is over
                      GameOver = true;
                      if (!GameOver)
                      {
                         

                      }
                      else {
                          await Page.Navigation.PopAsync();
                      }
                  }));
            }
        }

        Command playAgainCommand;
        public Command PlayAgainCommand
        {
            get
            {
                return playAgainCommand ??
                  (playAgainCommand = new Command(() =>
                  {
                      
                      CurrentGame = new string[3, 3];
                      Play0 = string.Empty;
                      Play1 = string.Empty;
                      Play2 = string.Empty;
                      Play3 = string.Empty;
                      Play4 = string.Empty;
                      Play5 = string.Empty;
                      Play6 = string.Empty;
                      Play7 = string.Empty;
                      Play8 = string.Empty;
                      HumanPlayer = true;
                      GameOver = false;
                      Moves = 0;
                      HumanMoves = 0;
                      AIMoves = 0;
                      ShowResult(false);
                      Device.StartTimer(TimeSpan.FromMinutes(0.1), () =>
                      {
                          if (Moves == 0)
                          {
                              InitiateAIPlayer();
                          }
                          return false;
                      });
                  }));
            }
        }

        Command<string> playCommand;
        public Command<string> PlayCommand
        {
            get
            {
                return playCommand ??
                    (playCommand = new Command<string>((p) => Play(p)));
            }
        }


        public void Play(string number)
        {
            if (GameOver)
                return;

            int x = 0;
            int y = 0;
            switch (number)
            {
                case "0":
                    break;
                case "1":
                    x = 1;
                    y = 0;
                    break;
                case "2":
                    x = 2;
                    y = 0;
                    break;
                case "3":
                    x = 0;
                    y = 1;
                    break;
                case "4":
                    x = 1;
                    y = 1;
                    break;
                case "5":
                    x = 2;
                    y = 1;
                    break;
                case "6":
                    x = 0;
                    y = 2;
                    break;
                case "7":
                    x = 1;
                    y = 2;
                    break;
                case "8":
                    x = 2;
                    y = 2;
                    break;
                default:
                    return;
            }

            if (CurrentGame[x, y] != null || IsBusy)
                return;

            if (HumanPlayer)
            {
                CurrentGame[x, y] = "X";
                HumanMoves++;
            }
            else
            {
                CurrentGame[x, y] = "O";
                AIMoves++;
            }

            switch (number)
            {
                case "0":
                    Play0 = GetImage(CurrentGame[x, y]);
                    break;
                case "1":
                    Play1 = GetImage(CurrentGame[x, y]);
                    break;
                case "2":
                    Play2 = GetImage(CurrentGame[x, y]);
                    break;
                case "3":
                    Play3 = GetImage(CurrentGame[x, y]);
                    break;
                case "4":
                    Play4 = GetImage(CurrentGame[x, y]);
                    break;
                case "5":
                    Play5 = GetImage(CurrentGame[x, y]);
                    break;
                case "6":
                    Play6 = GetImage(CurrentGame[x, y]);
                    break;
                case "7":
                    Play7 = GetImage(CurrentGame[x, y]);
                    break;
                case "8":
                    Play8 = GetImage(CurrentGame[x, y]);
                    break;
                default:
                    return;
            }

            Moves++;
            CheckResults();

            if (!GameOver)
            {
                HumanPlayer = !HumanPlayer;
                if (!HumanPlayer)
                {
                    IsBusy = true;

                    Device.StartTimer(TimeSpan.FromMinutes(0.1), () =>
                    {
                        IsBusy = false;
                        Play(makeAIMove().ToString());
                        return false;
                    });
                }
            }
        }

        public int makeAIMove() {
           
            int[,] game = new int[3, 3];

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {

                    if (CurrentGame[i, j] == "X")
                    {
                        game[i, j] = 2;
                    }
                    else if(CurrentGame[i, j] == "O") {
                        game[i, j] = 10;
                    }
                }
            }

            int[,] winningCombos =
           {
                {game[0,0], game[0,1], game[0,2]},
                {game[1,0], game[1,1], game[1,2]},
                {game[2,0], game[2,1], game[2,2]},
                {game[0,0], game[1,0], game[2,0]},
                {game[0,1], game[1,1], game[2,1]},
                {game[0,2], game[1,2], game[2,2]},
                {game[0,0], game[1,1], game[2,2]},
                {game[0,2], game[1,1], game[2,0]}
            };
            int[,,] winningIndexes =
          {
                {{0,0}, {0,1}, {0,2} },
                {{1,0}, {1,1}, {1,2} },
                {{2,0}, {2,1}, {2,2}},
                {{0,0}, {1,0}, {2,0} },
                {{0,1}, {1,1}, {2,1} },
                {{0,2}, {1,2}, {2,2} },
                {{0,0}, {1,1},{2,2 } },
                {{0,2}, {1,1},{2,0} }
            };

            for (int i = 0; i < 8; i++)
            {
                if (winningCombos[i, 0] + winningCombos[i, 1] + winningCombos[i, 2] == 20)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (winningCombos[i, j] == 0)
                        {
                            return GetGridPosition(winningIndexes[i, j, 0], winningIndexes[i, j, 1]);
                        }

                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {

                if (winningCombos[i, 0] + winningCombos[i, 1] + winningCombos[i, 2] == 4)
                {
                    for (int j = 0; j < 3; j++) {
                        if (winningCombos[i, j] == 0)
                        {
                            return GetGridPosition(winningIndexes[i, j,0], winningIndexes[i, j,1]);
                        }

                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (winningCombos[i, 0] + winningCombos[i, 1] + winningCombos[i, 2] == 10)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (winningCombos[i, j] == 0)
                        {
                            return GetGridPosition(winningIndexes[i, j, 0], winningIndexes[i, j, 1]);
                        }

                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (winningCombos[i, 0] + winningCombos[i, 1] + winningCombos[i, 2] == 2)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (winningCombos[i, j] == 0)
                        {
                            return GetGridPosition(winningIndexes[i, j, 0], winningIndexes[i, j, 1]);
                        }

                    }
                }
            }
            return 1;
        }

        public void InitiateAIPlayer() {
            IsBusy = true;
            Device.StartTimer(TimeSpan.FromMinutes(0.1), () =>
            {

                IsBusy = false;
                HumanPlayer = false;
                Play(makeAIMove().ToString());
                return false;
                
            });
           
        }
        public int GetGridPosition(int x, int y)  
            {

            if (x == 0 && y == 1)
                return 3;
            else if (x == 0 && y == 2)
                return 6;
            else if (x == 1 && y == 0)
                return 1;
            else if (x == 1 && y == 1)
                return 4;
            else if (x == 1 && y == 2)
                return 7;
            else if (x == 2 && y == 0)
                return 2;
            else if (x == 2 && y == 1)
                return 5;
            else if (x == 2 && y == 2)
                return 8;
         
            return 0;
        }

        public void CheckResults()
        {
            string[,] winningCombos =
            {
                {CurrentGame[0,0], CurrentGame[0,1], CurrentGame[0,2]},
                {CurrentGame[1,0], CurrentGame[1,1], CurrentGame[1,2]},
                {CurrentGame[2,0], CurrentGame[2,1], CurrentGame[2,2]},
                {CurrentGame[0,0], CurrentGame[1,0], CurrentGame[2,0]},
                {CurrentGame[0,1], CurrentGame[1,1], CurrentGame[2,1]},
                {CurrentGame[0,2], CurrentGame[1,2], CurrentGame[2,2]},
                {CurrentGame[0,0], CurrentGame[1,1], CurrentGame[2,2]},
                {CurrentGame[0,2], CurrentGame[1,1], CurrentGame[2,0]}
            };

            for (int i = 0; i < 8; i++)
            {

                if ((winningCombos[i, 0] == "X") & (winningCombos[i, 1] == "X") & (winningCombos[i, 2] == "X"))
                {
                    ShowResult(true);
                    GameOver = true;
                    GameResult = "You Win!";
                    GameResultImage = "facehappy.png";
                    OnPropertyChanged(nameof(GameResult));
                    OnPropertyChanged(nameof(GameResultImage));
                    Settings.Current.TotalWins = (int.Parse(Settings.Current.TotalWins) + 1).ToString(); ;
                    return;
                }

                if ((winningCombos[i, 0] == "O") & (winningCombos[i, 1] == "O") & (winningCombos[i, 2] == "O"))
                {
                    ShowResult(true);
                    GameOver = true;
                    GameResult = "You Lose!";
                    GameResultImage = "facesad.png";
                    OnPropertyChanged(nameof(GameResult));
                    OnPropertyChanged(nameof(GameResultImage));
                    Settings.Current.TotalLoss = (int.Parse(Settings.Current.TotalLoss) + 1).ToString();
                    return;
                }

            }


            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (CurrentGame[x, y] == null)
                        return;
                }
            }

            //Draw!
            ShowResult(true);
            GameResult = "That's a draw!";
            GameResultImage = "faceindifferent.png";
            OnPropertyChanged(nameof(GameResult));
            OnPropertyChanged(nameof(GameResultImage));
            GameOver = true;
            return;
        }

        public void ShowResult(bool show)
        {
            GameResultVisible = show;
            GameResultImageVisible = show;
            PlayAgainVisible = show;
            OnPropertyChanged(nameof(PlayAgainVisible));

            OnPropertyChanged(nameof(GameResultVisible));
            OnPropertyChanged(nameof(GameResultImageVisible));
          

        }
        public string GetImage(string Token) {
            if (Token.Equals("O"))
            {
                int move = AIMoves;
                move = move > 3 ? move -= 3 : move;
                return "o" + move + ".png";
            }
            else {
                int move = HumanMoves;
                move = move > 3 ? move -= 3 : move;
                return "x" + move + ".png";
            }

        }

    }
}
