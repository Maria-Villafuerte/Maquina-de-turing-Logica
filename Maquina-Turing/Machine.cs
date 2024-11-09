class Machine
{
    public string input {get; set;}
    public string[] states {get; set;}
    public string[] alphabet {get; set;}
    public string[] alphabet_pile {get; set;}
    public string blanc_symbol {get; set;}
    public string acceptances_state {get; set;}
    public string reject_state {get; set;}

    public Machine(string Input, string[] States, string[] Alphabet, 
		    string[] Alphabet_pile, string Blanc_symbol, 
		    string Acceptances_state, string Reject_state) {
	input = Input;
	states = States;
	alphabet = Alphabet;
	alphabet_pile = Alphabet_pile;
	blanc_symbol = Blanc_symbol;
	acceptances_state = Acceptances_state;
	reject_state = Reject_state;
    }
}
