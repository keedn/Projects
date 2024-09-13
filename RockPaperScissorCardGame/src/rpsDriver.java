import java.util.Scanner;
import java.util.Random;
import javax.swing.*;
import java.awt.*;


public class rpsDriver {

    //Create enum for all Card Types Card "X" = new Card(CardType."enum");
    public enum cardType{
        ROCK,
        PAPER,
        SCISSOR
    }

    public static void main(String[] args) {

        boolean gameOn =true;
        int playerLife = 1;
        int botLife = 1;

        // 0 - 3 | 0 = Rock , 1 = Paper, 2 = Scissors |
        Random rand = new Random(2);

        // Create frame
        LabelFrame labelFrame = new LabelFrame();

        // Game Loop
        while(gameOn = true){


            labelFrame.setVisible(true);

            // If either life is "dead" 0 then end game / leave loop
            if(playerLife == 0 || botLife == 0){
                gameOn = false;
            }



        }
        public int(enum cardType,cardType){

        };
    }










}