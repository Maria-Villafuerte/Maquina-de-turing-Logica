import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

public class TuringMachineSimulation {
    public static void main(String[] args) {
        String path = "machine_loop.txt";
        String input = "";
        String[] states = {};
        String[] alphabet = {};
        String[] alphabetPile = {};
        String blancSymbol = "";
        String acceptanceState = "";
        String rejectState = "";
        String initialState = "";
        Map<String, String> transitions = new HashMap<>();

        try (BufferedReader br = new BufferedReader(new FileReader(path))) {
            String line;
            int lineIndex = 0;

            while ((line = br.readLine()) != null) {
                if (lineIndex == 0) {
                    input = line;
                } else if (lineIndex == 1) {
                    states = line.split(",");
                } else if (lineIndex == 2) {
                    alphabet = line.split(",");
                } else if (lineIndex == 3) {
                    alphabetPile = line.split(",");
                } else if (lineIndex == 4) {
                    blancSymbol = line;
                } else if (lineIndex == 5) {
                    acceptanceState = line;
                } else if (lineIndex == 6) {
                    rejectState = line;
                } else if (lineIndex == 7) {
                    initialState = line;
                } else {
                    String[] keyValue = line.split("\\|");
                    transitions.put(keyValue[0], keyValue[1]);
                }
                lineIndex++;
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        Machine turingMachine = new Machine(input, states, alphabet, alphabetPile, blancSymbol, acceptanceState,
                rejectState, initialState, transitions);
        boolean acceptation = turingMachine.derivation();

        if (acceptation) {
            System.out.println("El input fue aceptado\nGenerando la información de la Máquina de Turing...");
            turingMachine.generateData(true);
        } else {
            System.out.println("El input NO fue aceptado\nGenerando la información de la Máquina de Turing...");
            turingMachine.generateData(false);
        }
    }
}
