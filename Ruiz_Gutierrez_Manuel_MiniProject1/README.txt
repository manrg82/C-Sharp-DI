Name: Manuel Ruiz Gutiérrez
This project consists of:
	-Program.cs file: is the "main" class of the project and calls an instance of the "Board" class
	-Board.cs file: contains the vast majority of the logic in the file, it is mostly comprised of:
		-bool[][] dataBoard: the bi-dimensional array of booleans that comprises the board, whenever the other funcions generate and place down the boats they get stored in here
		-int maxSize: the max size of the boats, asked for whenever an object of the "Board" class is instanced in order to generate the board itself
		-int amt: it's the maximum amount of boats that can exist at all times, as of now it can only be 5
		-public Board() (constructor): creates dataBoard and assigs the values for all other variables, alse asks for the value of maxSize in the console
		-placeBoats()://places the boat in the coordinates using assignBoatAtSpot()//places the boat in the coordinates using assignBoatAtSpot()
		-assignBoatAtSpot(int x, int y, int actualSize):assigns the boat the coordinates given in the params, x & y being the coordinates in which to place each boat and actualSize is the length that the boat
			is going to have which is generated at random between 1 and the maxSize. It's an auxiliary method of placeBoats()
		-printBoard(): prints out the contents of dataBoard in which true="B " and false=". "