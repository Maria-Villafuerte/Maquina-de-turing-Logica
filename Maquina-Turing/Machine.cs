class Machine
{
    public string input {get; set;}
    public string[] states {get; set;}
    public string[] alphabet {get; set;}
    public string[] alphabet_pile {get; set;}
    public string blanc_symbol {get; set;}
    public string acceptances_state {get; set;}
    public string reject_state {get; set;}
	public string initial_state {get; set;}
	public Dictionary<string, string> transitions {get; set;}

    public Machine(string Input, string[] States, string[] Alphabet, 
		    string[] Alphabet_pile, string Blanc_symbol, 
		    string Acceptances_state, string Reject_state,
			string Initial_state, Dictionary<string, string> Transitions) {
	input = Input;
	states = States;
	alphabet = Alphabet;
	alphabet_pile = Alphabet_pile;
	blanc_symbol = Blanc_symbol;
	acceptances_state = Acceptances_state;
	reject_state = Reject_state;
	initial_state = Initial_state;
	transitions = Transitions;
    }

    private List<string> tape_initialization(string input, string blanc) 
    {
    	List<string> input_tape = new List<string> { blanc, blanc };
	for (int i = 0; i < input.Length; i++)
	{
		input_tape.Add(Convert.ToString(input[i]));
	}

	input_tape.Add(blanc);
	input_tape.Add(blanc);

	return input_tape;
    }

	public bool derivation() 
	{
		List<string> tape = tape_initialization(input, blanc_symbol);
		string state = initial_state;
		int index = 2;
		string char_tape = tape[index];

		while (!state.Equals(acceptances_state) && !state.Equals(reject_state))
		{
			string value = transition(state, char_tape);
			string[] value_list = value.Split(",");
			
			state = value_list[0]; //Change old state for new one
			tape[index] = value_list[1]; //Change the char in the tape
			if (value_list[2].Equals("R"))
			{
				index += 1;
			}
			else
			{
				index -= 1;
			}

			char_tape = tape[index]; //New char to read in tape
		}

		if (state.Equals(acceptances_state))
		{
			return true;
		}
		
		return false;
	}

	private string transition(string state, string char_tape) {
		string key = state + ',' + char_tape;
		string value = transitions[key];

		return value;
	}

	public void generate_data()
	{
		var formattedTransitions = transitions.Select(kv => $"({kv.Key}) : ({kv.Value})");

		string output_path = "output.txt";
		string content = 
		"Q: "+ states.ToString() + "\n" +
		"Σ: " + alphabet.ToString() + "\n" +
		"Γ: " + alphabet_pile.ToString() + "\n" +
		"q0: " + initial_state + "\n" +
		"Qaccept: " + acceptances_state + "\n" +
		"Qreject: " + reject_state + "\n" +
		"δ: \n" + "{\n" +
		string.Join("\n", formattedTransitions) +
		"\n}";

		File.WriteAllText(output_path, content);
	}

	
}
