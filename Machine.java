import java.util.*;

public class Machine {
    private String input;
    private String[] states;
    private String[] alphabet;
    private String[] alphabetPile;
    private String blancSymbol;
    private String acceptanceState;
    private String rejectState;
    private String initialState;
    private Map<String, String> transitions;
    private List<String> configurations;

    public Machine(String input, String[] states, String[] alphabet, String[] alphabetPile, String blancSymbol,
            String acceptanceState, String rejectState, String initialState, Map<String, String> transitions) {
        this.input = input;
        this.states = states;
        this.alphabet = alphabet;
        this.alphabetPile = alphabetPile;
        this.blancSymbol = blancSymbol;
        this.acceptanceState = acceptanceState;
        this.rejectState = rejectState;
        this.initialState = initialState;
        this.transitions = transitions;
        this.configurations = new ArrayList<String>();
    }

    private List<String> tapeInitialization(String input, String blanc) {
        List<String> inputTape = new ArrayList<>(Arrays.asList(blanc, blanc));
        for (int i = 0; i < input.length(); i++) {
            inputTape.add(String.valueOf(input.charAt(i)));
        }
        inputTape.add(blanc);
        inputTape.add(blanc);
        return inputTape;
    }

    public boolean derivation() {
        List<String> tape = tapeInitialization(input, blancSymbol);
        String state = initialState;
        int index = 2;
        String charTape = tape.get(index);

        while (!state.equals(acceptanceState) && !state.equals(rejectState)) {
            String value = transition(state, charTape);
            String[] valueList = value.split(",");

            state = valueList[0]; // Change old state for new one
            tape.set(index, valueList[1]); // Change the char in the tape
            if (valueList[2].equals("R")) {
                index += 1;
            } else {
                index -= 1;
            }

            saveConfig(tape.toString(), index, state);

            if (configurations.size() > 50) {
                configurations.add("\n*****Loop*****\n");
                return false;
            }

            charTape = tape.get(index); // New char to read in tape
        }

        return state.equals(acceptanceState);
    }

    private String transition(String state, String charTape) {
        String key = state + "," + charTape;
        return transitions.get(key);
    }

    public void generateData(boolean result) {
        String outputPath = "output.txt";
        String content = configurations.toString();
        content = content.replaceAll("[\\[\\] \\s]", "") // Elimina '[' y ']'
                .replace(",", "\n"); // Reemplaza las comas por saltos de línea

        if (result) {
            content += "\n\nCadena aceptada";
        } else {
            content += "\n\nCadena rechazada";
        }

        try {
            java.nio.file.Files.write(java.nio.file.Paths.get(outputPath), content.getBytes());
        } catch (java.io.IOException e) {
            e.printStackTrace();
        }
    }

    private void saveConfig(String actualTape, int index, String state) {
        String str = actualTape.replaceAll("[\\[\\],\\s]", "");
        String firstHalf = str.substring(0, index - 1);
        String lastHalf = str.substring(index, str.length() - 1);

        configurations.add(firstHalf + state + lastHalf);
    }
}
