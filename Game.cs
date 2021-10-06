using System;

namespace Spaceman
{
  class Game {
    
    public string Codeword  ;
    public string CurrentWord{get;set;}
    public int MaxNumberGuesses;
    public int WrongGuesses;
    private string[] arrayCodeWord = {"pipa", "calamar", "aventura", "literal"};

     Ufo ufo = new Ufo();

    //private string newCodeword = "UFO, the game";
    public Game() {
      Codeword = arrayCodeWord[new Random().Next(arrayCodeWord.Length)];
      MaxNumberGuesses = 5;
      WrongGuesses = 0;
      CurrentWord = Underscore();
    }
    //  
    public void Greet() {
      Console.WriteLine("===================\n"); 
      Console.WriteLine("   UFO, the game\n"); 
      Console.WriteLine("==================="); 
    }

    //  word to a string of underscores
    private string Underscore() {
      string underscores  ="";

      for(int i = 0; i < Codeword.Length; i++) {
        underscores  +="-";
      }
      return underscores ;
    } 

    //player won true otherwise false
    public bool DidWing() {
      return Codeword.Equals(CurrentWord);
    }
    
    //check player lost
    public bool DidLose() {
      return WrongGuesses >= MaxNumberGuesses;
    }

    public void Display() {
      Console.WriteLine(ufo.Stringify());
      Console.WriteLine($"Current word: {CurrentWord}");
      Console.WriteLine($"Incorrect guesses: {WrongGuesses}");

    }
    public void Ask() {
        do{
            Display();
            Console.Write("Guess a Letter: ");
            char guessLetter = isCharacter();
            char[] arrayGuessLetter = CurrentWord.ToCharArray();
           
            if(Codeword.Contains(guessLetter)) {
                for(int i = 0; i < Codeword.Length; i++ ) {
                    if(Codeword[i] == guessLetter ) {
                        arrayGuessLetter[i] = guessLetter;
              } 
            }
                this.CurrentWord = new String(arrayGuessLetter);      
            } else {
                WrongGuesses++;
                ufo.AddPart();
                Display();
            }
        }while (!(DidWing() || DidLose()));
        
        if(DidWing()) {
            Console.WriteLine($"Great has guessed the word is: {Codeword}");
        } else {
            Console.WriteLine("Sorry, you loose, try again");
        }
    }
    
    // ask introduce a valid char otherwise, loop until you write a right char 
     private char isCharacter() {
       bool repeat = true;
       string guessLetter = "";
       do {
         guessLetter = Console.ReadLine();
         if(guessLetter != String.Empty) {
           
            if (guessLetter.Length == 1) {
              repeat = false;
            } else {
              Console.WriteLine($"This is not a letter {guessLetter}, try again!!");
            }
          }
       } while(repeat); 
       return guessLetter[0] ;
     }
  }
}