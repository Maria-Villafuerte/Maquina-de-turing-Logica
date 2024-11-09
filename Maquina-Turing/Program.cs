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
string initial_state = "";
Dictionary<string, string> transitions = new Dictionary<string, string>();

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
	else if (x == 6)
	{
		reject_state = lines[x];	    	
	}
	else if (x == 7)
	{
	    	initial_state = lines[x];
	}
	else
	{
		string[] key_value = lines[x].Split("|");
		transitions.Add(key_value[0],key_value[1]);
	}
}

Machine turing_machine = new Machine(input, states, alphabet, alphabet_pile, blanc_symbol, acceptance_state, reject_state, initial_state,transitions);
bool acceptation = turing_machine.derivation();

if (acceptation)
{
Console.WriteLine("El input fue aceptado\nGenerando la información de la Máquina de Turing...");
turing_machine.generate_data();
}
else
{
Console.WriteLine("El input no fue aceptado\nNo se genera la información de la Máquina de Turing");
}
