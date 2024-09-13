import javax.swing.*;
import java.awt.*;
import java.util.Random;

public class LabelFrame extends JFrame {

    private final JLabel inputMessage = new JLabel();
    private final JLabel outputMessage = new JLabel();

    //Constructor for Main Frame
    public LabelFrame() {
        super("Rock Paper Scissors"); // Sets the title of Game
        setLayout(new FlowLayout()); // Set the layout manager
        add(inputMessage); // Adds input message label
        add(outputMessage); // " "
        setSize(300, 200);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); // make sure frame closes when exit
        setVisible(true); // Makes frame visible
    }





}