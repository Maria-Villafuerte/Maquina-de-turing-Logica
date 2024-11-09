// See https://aka.ms/new-console-template for more information

string path = "machine_data.txt";
string[] lines = File.ReadAllLines(path);

//Machine variables
string input = "";
string[] states = [];
string[] alphabet = [];
string[] alphabet_pile = [];
string blanc_symbol = "";
string acceptance_state = "";
string reject_state = "";

for (int x = 0; x < lines.Length; x++)
{
	if (x == 0) {
		input = lines[x];
	} 
	else if (x == 1) 
	{
		states = lines[x].Split(",");
	}
	else if (x == 2)
	{
		alphabet = lines[x].Split(",");
	}
	else if (x == 3)
	{
	    	alphabet_pile = lines[x].Split(",");
	}
	else if (x == 4)
	{
	   	blanc_symbol = lines[x]; 
	}
	else if (x == 5)
	{
	    	acceptance_state = lines[x];
	} 
	else
	{
		reject_state = lines[x];	    	
	}
}

Machine turing_machine = new Machine(input, states, alphabet, alphabet_pile, blanc_symbol, acceptance_state, reject_state);
Console.WriteLine(turing_machine.input);
