///Present Issues:
//Date input and sorting not implemented

///Todo:


using System;
using System.IO;
using System.Linq;

public class algComplex
{
	public static void Main(string[] args)
	{	
		//Data added from files
		string[] sort_months = File.ReadAllLines("sorting_months.txt");
		string[] sort_months_r = File.ReadAllLines("sorting_months_r.txt");
		string[] sort_base = File.ReadAllLines("sorting_base.txt");
		string[] sort_base_r = File.ReadAllLines("sorting_base_r.txt");
		
		
		
		///Inputing dataset
		// string[] dataset = File.ReadAllLines("dataset_1.txt");
		// string[] dataLength = File.ReadAllLines(dataset[0]);
		
		// string dataTable = new string[dataLength.Length, dataset.Length];
		
		// for (int x = 0; x < dataTable.GetLength(1); x++){
			// string datasetN = File.ReadAllLines(dataset[x]);
			// for (int y = 0; y < dataTable.GetLength(0); y++){
				// dataTable[y, x] = datasetN[y]
			// }
		// }
		
		
		
		//Inputing dataset
		string[] dataset = File.ReadAllLines("dataset_1.txt");
		string[] data1 = File.ReadAllLines(dataset[0]);
		string[] data2 = File.ReadAllLines(dataset[1]);
		string[] data3 = File.ReadAllLines(dataset[2]);
		string[] data4 = File.ReadAllLines(dataset[3]);
		string[] data5 = File.ReadAllLines(dataset[4]);
		string[] data6 = File.ReadAllLines(dataset[5]);
		string[] data7 = File.ReadAllLines(dataset[6]);
		string[] data8 = File.ReadAllLines(dataset[7]);
		string[] data9 = File.ReadAllLines(dataset[8]);
		string[] data10 = File.ReadAllLines(dataset[9]);
		string[] data11 = File.ReadAllLines(dataset[10]);
		
		//Data added to multidimensional array
		string[,] dataTable = new string[data1.Length, 11];
		///string[] dataTemp_Str = new string[data1.Length];
		///int[] dataTemp_Int = new int[data1.Length];
		
		for (int x = 0; x < data1.Length; x++){
			dataTable[x, 0] = data1[x];
			dataTable[x, 1] = data2[x];
			dataTable[x, 2] = data3[x];
			dataTable[x, 3] = data4[x].PadRight(10, ' ');
			dataTable[x, 4] = data5[x].PadLeft(2, ' ');
			dataTable[x, 5] = data6[x];
			dataTable[x, 7] = data8[x].PadLeft(8, ' ');
			dataTable[x, 6] = data7[x].PadLeft(8, ' ');
			dataTable[x, 8] = data9[x].PadLeft(8, ' ');
			dataTable[x, 9] = data10[x].PadLeft(8, ' ');
			dataTable[x, 10] = data11[x].PadRight(25, ' ');
		}
		
		//choose what to sort by..
		bool loop = true;
		while (loop) {
			Console.WriteLine("WHAT WOULD YOU LIKE TO DO?");
			Console.Write("PRINT(0) or SORT(1) or SEARCH(2) or SELECT_DATASET(3) [#]: ");
			string option = Console.ReadLine();
			
			if (option == "0"){
				//Output: Data Table
				Console.WriteLine("Data Table:");
				for (int x = 0; x < dataTable.GetLength(0); x++){
					Console.Write(" ");
					for (int y = 0; y < dataTable.GetLength(1); y++){
						Console.Write(dataTable[x,y]);
						if (dataTable.GetLength(1)-1 != y){Console.Write(" ¦ ");} //Item Seperator
					}
					Console.Write("\n");
				}
			}
			else if (option == "1"){
				Console.WriteLine("What part of the data would you like to sort by?");
				Console.Write("Choose column ID to sort by [1~11]: ");
				
				//*
				string strInput = Console.ReadLine();
				int option1;
				bool result = Int32.TryParse(strInput, out option1);
				if (result == true){
					if (option1 < 1 | option1 > 11){
						result = false;
					}
				}
				while (result == false){
					Console.WriteLine("Enter a valid number in the range.");
					Console.WriteLine("What part of the data would you like to sort by?");
					Console.Write("Choose column ID to sort by [1~11]: ");
					strInput = Console.ReadLine();
					result = Int32.TryParse(strInput, out option1);
					if (result == true){
						if (option1 < 1 | option1 > 11){
							result = false;
						}
					}
				}
				option1--;
				/**/
				
				Console.WriteLine("\nHow would you like to sort the data?");
				Console.Write("Asc(1) or Desc(2) [#]: ");
				string option2 = Console.ReadLine();
				
				if (sort_months.Contains(dataTable[0,option1].Replace(" ", ""))){
					if (option2 == "1"){
						sortMonths(dataTable, option1, sort_months);
						sortMonths(dataTable, option1, sort_months);
					} else if (option2 == "2"){
						sortMonths(dataTable, option1, sort_months_r);
						sortMonths(dataTable, option1, sort_months_r);
					}
				} else {
					if (option2 == "1"){
						shiftSort(dataTable, option1, sort_base);
						shiftSort(dataTable, option1, sort_base);
					} else if (option2 == "2"){
						shiftSort(dataTable, option1, sort_base_r);
						shiftSort(dataTable, option1, sort_base_r);
					}
				}
			} 
			else if (option == "2"){
				Console.WriteLine("How would you like to search?");
				Console.Write("Search for: IRIS_ID (1) | DATA (2) | DATE (3) | MIN VAL (4) | MAX VAL (5)[#]: ");
				string option3 = Console.ReadLine();

				if (option3 == "1"){
					Console.Write("Enter IRIS_ID to search for [#]: ");
					string option4 = Console.ReadLine();
					
					Console.WriteLine("Row: " + option4);
					
					for (int x = 0; x < dataTable.GetLength(0); x++){
						if (dataTable[x, 0] == option4){
							for (int y = 0; y < dataTable.GetLength(1); y++){
								Console.Write(dataTable[x, y]);
								if (dataTable.GetLength(1)-1 != y){Console.Write(" ¦ ");}
							}
						}
					}
					
					Console.WriteLine();
					Console.WriteLine();
					
				} 
				else if (option3 == "2"){
					Console.WriteLine("Enter the EXACT string datapiece to search for:");
					string option5 = Console.ReadLine();
					
					Console.WriteLine("\nEntries containing: " + option5);
					
					for (int x = 0; x < dataTable.GetLength(0); x++){
						for (int y = 0; y < dataTable.GetLength(1); y++){ 			//for each elem in 2d arry 
							if (dataTable[x,y].Replace(" ", "") == option5.Replace(" ", "")){
								for (int w = 0; w < dataTable.GetLength(1); w++){	//
									Console.Write(dataTable[x, w]);
									if (dataTable.GetLength(1)-1 != w){Console.Write(" ¦ ");}
								}
								Console.WriteLine();
							}
						}
					}
					Console.WriteLine("\n\n");
				}
				else if (option3 == "3"){
					Console.WriteLine("Enter the YEAR to search for:");
					string option6 = Console.ReadLine();
					
					Console.WriteLine("Enter the MONTH to search for:");
					string option7 = Console.ReadLine();
					
					Console.WriteLine("Enter the DAY to search for:");
					string option8 = Console.ReadLine();
					
					Console.WriteLine("\nEntries from: {0} {1} {2}", option8, option7, option6);
					bool noDate = true;
					
					for (int x = 0; x < dataTable.GetLength(0); x++){
						// Console.Write("¬{0}", dataTable[4,x]);
						if (dataTable[x, 2].Replace(" ", "") == option6.Replace(" ", "")){
							if (dataTable[x, 3].Replace(" ", "") == option7.Replace(" ", "")){
								if (dataTable[x, 4].Replace(" ", "") == option8.Replace(" ", "")){
									Console.WriteLine();
									noDate = false;
									for (int y = 0; y < dataTable.GetLength(1); y++){
										Console.Write(dataTable[x, y]);
										if (dataTable.GetLength(1)-1 != y){Console.Write(" ¦ ");}
									}
								}
							}
						}
					}
					if (noDate == true){	Console.WriteLine("This date does not appear in the data.");	}
					Console.WriteLine("\n\n");
				}
				else if (option3 == "4"){
						
					Console.WriteLine("What part of the data would you like to find a minimium?");
					Console.Write("Choose column ID to search [1~11]: ");
					int option1 = Convert.ToInt32(Console.ReadLine())-1;
					if (sort_months.Contains(dataTable[0,option1].Replace(" ", ""))){
						sortMonths(dataTable, option1, sort_months);
						sortMonths(dataTable, option1, sort_months);
					} else {
						shiftSort(dataTable, option1, sort_base);
						shiftSort(dataTable, option1, sort_base);
					}
					Console.WriteLine("\nThe Minimum value for the column chosen is: {0}\n", dataTable[0, option1]);
				}
				else if (option3 == "5"){
						
					Console.WriteLine("What part of the data would you like to find a maximum?");
					Console.Write("Choose column ID to search [1~11]: ");
					int option1 = Convert.ToInt32(Console.ReadLine())-1;
					if (sort_months.Contains(dataTable[0,option1].Replace(" ", ""))){
						sortMonths(dataTable, option1, sort_months_r);
						sortMonths(dataTable, option1, sort_months_r);
					} else {
						shiftSort(dataTable, option1, sort_base_r);
						shiftSort(dataTable, option1, sort_base_r);
					}
					Console.WriteLine("\nThe Maximum value for the column chosen is: {0}\n", dataTable[0, option1]);
				}
			}
			else if (option == "3"){
				Console.Write("Enter the dataset title: ");
				string dataset_title = Console.ReadLine();
				//Inputing dataset
				dataset = File.ReadAllLines("dataset_" + dataset_title + ".txt");
				data1 = File.ReadAllLines(dataset[0]);
				data2 = File.ReadAllLines(dataset[1]);
				data3 = File.ReadAllLines(dataset[2]);
				data4 = File.ReadAllLines(dataset[3]);
				data5 = File.ReadAllLines(dataset[4]);
				data6 = File.ReadAllLines(dataset[5]);
				data7 = File.ReadAllLines(dataset[6]);
				data8 = File.ReadAllLines(dataset[7]);
				data9 = File.ReadAllLines(dataset[8]);
				data10 = File.ReadAllLines(dataset[9]);
				data11 = File.ReadAllLines(dataset[10]);
				
				//Data added to multidimensional array
				for (int x = 0; x < data1.Length; x++){
					dataTable[x, 0] = data1[x];
					dataTable[x, 1] = data2[x];
					dataTable[x, 2] = data3[x];
					dataTable[x, 3] = data4[x].PadRight(10, ' ');
					dataTable[x, 4] = data5[x].PadLeft(2, ' ');
					dataTable[x, 5] = data6[x];
					dataTable[x, 7] = data8[x].PadLeft(8, ' ');
					dataTable[x, 6] = data7[x].PadLeft(8, ' ');
					dataTable[x, 8] = data9[x].PadLeft(8, ' ');
					dataTable[x, 9] = data10[x].PadLeft(8, ' ');
					dataTable[x, 10] = data11[x];
				}
			}
		}
	}
	




	public static void sortMonths(string[,] dataType, int op1, string[] dataSort){
		
		
		Console.WriteLine();
		
		string[] current = new string[2];							///used to hold current data
		string[] sorted =  new string[dataType.GetLength(0)];		///sorted elem
		string[] output =  new string[dataType.GetLength(0)];			///orig positions of sorted elem
		string[] input =   new string[dataType.GetLength(0)]; 		///unsorted elem
		
		for(int x=0;x<dataType.GetLength(0);x++){ 		///convert sorting data to index-able array
			input[x] = dataType[x,op1].Replace(" ", "");					///sort-element move to new array
		}
		
		for (int X=0; X < input.Length; X++){
			//Console.WriteLine("X " + X + " = " + input[X]);
			current[0] = input[X];
			current[1] = Convert.ToString(X);
			bool unsorted = true;
			int N = 0;
			
			while (unsorted == true) {
				if (sorted[N] == null) {
					sorted[N] = current[0];
					output[N] = current[1];
					unsorted = false;
					// Console.WriteLine("Placed " + sorted[N] + " in position: " + N + "        EMPTY SLOT");
				} else if (current[0] == sorted[N]){
					insert_shift(current, sorted, N, output);
					unsorted = false;
				} else {
					int cur = Array.IndexOf(dataSort, current[0]);
					int sor = Array.IndexOf(dataSort, sorted[N]);
					if (cur < sor){ 
						// Console.WriteLine("X = " + X +"      N = " + N + "      < val = " + current[0]);
						insert_shift(current, sorted, N, output);
						unsorted = false;
					} else if (cur > sor){
						// Console.WriteLine("X = " + X +"      N = " + N + "      > val = " + current[0]);
						N++;
					} else {	//a++
						// Console.WriteLine("X = " + X +"      N = " + N + "      = val = " + current[0]);
						insert_shift(current, sorted, N, output);
						unsorted = false;
						N++;

					}
				}
			}
		}
		
		string[,] temp2DArray = new string[dataType.GetLength(0), dataType.GetLength(1)];
		
		for (int x = 0; x < temp2DArray.GetLength(0); x++){
			for (int y = 0; y < temp2DArray.GetLength(1); y++){
				temp2DArray[x, y] = dataType[x, y];
			}
		}
		
		for (int x = 0; x < temp2DArray.GetLength(0); x++){
			for (int y = 0; y < temp2DArray.GetLength(1); y++){
				dataType[x, y] = temp2DArray[Convert.ToInt32(output[x]), y];
			}
		}
	}
	
	public static void shiftSort(string[,] dataType, int op1, string[] dataSort){
		
		Console.WriteLine();
		
		string[] current = new string[2];							///used to hold current data
		string[] sorted =  new string[dataType.GetLength(0)];		///sorted elem
		string[] output =  new string[dataType.GetLength(0)];		///orig positions of sorted elem
		string[] input =   new string[dataType.GetLength(0)]; 		///unsorted elem
		
		for(int x=0;x<dataType.GetLength(0);x++){ 		///convert sorting data to index-able array
			input[x] = dataType[x,op1];					///sort-element move to new array
		}
		
		for (int X=0; X < input.Length; X++){
			//Console.WriteLine("X " + X + " = " + input[X]);
			current[0] = input[X];
			current[1] = Convert.ToString(X);
			bool unsorted = true;
			int N = 0;							//Position of sorted being tested against
			int a = 0;							//Position of char for current being tested
			while (unsorted == true) {
				if (sorted[N] == null) {
					sorted[N] = current[0];
					output[N] = current[1];
					unsorted = false;
					// Console.WriteLine("{0} SS:lbl:1		{1}	:{2} 	{3}:", N, current[0], current[0][a], sorted[N]);
					// Console.WriteLine("Placed " + sorted[N] + " in position: " + N + "        EMPTY SLOT");
				} else if (current[0] == sorted[N]){
					insert_shift(current, sorted, N, output);
					unsorted = false;
					// Console.WriteLine("{0}	SS:lbl:2		{1}	:{2} 	{3}:", N, current[0], current[0][a], sorted[N]);
				} else {
					int cur = Array.IndexOf(dataSort, Convert.ToString(current[0][a]));
					// Console.WriteLine("{0}		SS:lbl:3		{1}	:{2} 	{3}:", N, current[0], current[0][a], sorted[N]);
					int sor = Array.IndexOf(dataSort, Convert.ToString(sorted[N][a]));
					if (cur < sor){
						// Console.WriteLine("X = " + X +"      N = " + N + "      a = " + a + "      < val = " + current[0]);
						insert_shift(current, sorted, N, output);
						unsorted = false;
					} else if (cur > sor){
						// Console.WriteLine("X = " + X +"      N = " + N + "      a = " + a + "      > val = " + current[0]);
						N++;
						a = 0;
					} else {
						// Console.WriteLine("X = " + X +"      N = " + N + "      a = " + a + "      = val = " + current[0]);
						if (current[0].Length == a){
							insert_shift(current, sorted, N, output);
						} else {
							a++;
						}
					}
				}
			}
		}	
		string[,] temp2DArray = new string[dataType.GetLength(0), dataType.GetLength(1)];
		
		for (int x = 0; x < temp2DArray.GetLength(0); x++){
			for (int y = 0; y < temp2DArray.GetLength(1); y++){
				temp2DArray[x, y] = dataType[x, y];
			}
		}
		for (int x = 0; x < temp2DArray.GetLength(0); x++){
			for (int y = 0; y < temp2DArray.GetLength(1); y++){
				dataType[x, y] = temp2DArray[Convert.ToInt32(output[x]), y];
			}
		}
	}
	
	
	/*
	
		//[...first column sorted...]
		
		//create new 2d array (existing info placed in it)
		//temp2DArray[,] = dataType[,]
		//for each column
			//if column not occupied
				//for each in output
					//dataType[a] = temp2DArray[Convert.ToInt32(output[b])]
	*/
	
	public static void insert_shift(string[] curr, string[] sort, int n, string[] outp){
		//Console.WriteLine("INSERT SORT USED");
		
		int z = 0;
		for (int y = sort.Length-1; y >= 0; y--){
			if (sort[y] != null){
				z = y + 1;
				y = 0;
			}
		}
		
		for (int y = z ; y > n; y--){
			sort[y] = sort[y-1];
			outp[y] = outp[y-1];
		}
		
		sort[n] = curr[0];
		outp[n] = curr[1];
		//Console.WriteLine("                                    - - - - - - - - - -Placed " + sort[n] + " in position: " + n);
	}

/*
		//function shiftSort(input_data, sort_column, sort_data)

		//create array to hold current data          (current)
		//create array to hold sorted data           (sorted)
		//create array to hold sorted data positions (output)
		//create array to hold data to sort	     (input)

		//for each element in column (sort_column)
			//add to input array
		//for each element in input (X)
			//save item X to current	(current[0])
			//save value of X		(current[1])
			//unsorted = true
			//int N = 0
			//int a = 0
			//while unsorted
				//if position N == null
					//put item X in position N
					//unsorted = true
				//else
					//get item N (first elem in output) (sorted[N])
					//get char a of item N (sorted[N][a])
	
					//if position of current[0][a] comes before position of sorted[N][a] in sort_data
						//insert_shift(current, sorted, N)
						//unsorted = true
					//if position of current[0][a] comes after position of sorted[N][a] in sort_data
						//N++
					//if current[0][a] == sorted[N][a]
						//a++
						//if length of current[a] = a
							//insert_shift(current, sorted, N)
							//unsorted = true

		//function insert_shift(current, sorted, N)
			//for each position from final
				//if position not empty
					//save position value
					//break loop
			//for each element from saved position to first position
				//move element N to position, N+1
			//put item X in position N





*/
	/*	Define the Algorithm as O(N^2)  worst-case		*/	///Elements in reverse order and some elements begin with same characters
	/*	Define the Algorithm as O(N^2)  average-case	*/	///Elements in reverse order
	/*	Define the Algorithm as O(N)    best-case		*/	///Elements are ordered		
	

/*
			
			
			///label:intA
			
			for (int N = 0; N < current[0].Length; N++){
				
				for (int a = 0; a < current[0].Length; a++){
					
					Console.Write(current[0][a]+" < "+sorted[0][a]+" = ");
					Console.WriteLine(Array.IndexOf(dataSort, Convert.ToString(current[0][a])) < Array.IndexOf(dataSort, Convert.ToString(sorted[N][a])));
					
					if (Array.IndexOf(dataSort, Convert.ToString(current[0][a])) < Array.IndexOf(dataSort, Convert.ToString(sorted[N][a]))){ 		///if the current value being tested goes before the value in position N
						Console.WriteLine("<");
						for (int i = sorted.Length-1; i > N; i--){												///move all values from final position to position N (+1 places)
							if (sorted[i] != null){sorted[i+1] = sorted[i];}
						}
						sorted[N] = current[0];
						a = 0;
					} else if (Array.IndexOf(dataSort, current[0][a]) > Array.IndexOf(dataSort, sorted[N][a])){	///if the current value being tested goes after the value in position N
						Console.WriteLine(">");
						N += 1;
						a = 0;
						///test next value
						//GOTO label:intA
					} else { 																					///if the current values being tested are identical
						Console.WriteLine("=");
						if(current[0] == "0"){
							Console.WriteLine("=");
						}
						///compare next part of current and sorted values
						//GOTO label:intA
					}
				}
			}
		}		
			//find its position in array
			//get first char of item 1
			//find its position in array
			//for every item2 from first
				//if item1[n] == item2[n]
					//n += 1
				//else if item1[n].pos > item2[n].pos
					//test the next available item 2
				//else
					//for every item between last and current
						//item2.pos += 1
					//add item 1 to item2.pos
				
		Console.WriteLine("Sorting Alphanumerically");
	}


*/


	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}