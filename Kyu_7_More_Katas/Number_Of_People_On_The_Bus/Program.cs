namespace Number_Of_People_On_The_Bus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*There is a bus moving in the city which takes and drops some people at each bus stop.

            You are provided with a list (or array) of integer pairs. Elements of each pair represent 
            the number of people that get on the bus (the first item) and the number of people that get 
            off the bus (the second item) at a bus stop.

            Your task is to return the number of people who are still on the bus after the last bus stop 
            (after the last array). Even though it is the last bus stop, the bus might not be empty and 
            some people might still be inside the bus, they are probably sleeping there :D

            Take a look on the test cases.

            Please keep in mind that the test cases ensure that the number of people in the bus is always >= 0. 
            So the returned integer can't be negative.

            The second value in the first pair in the array is 0, since the bus is empty in the first bus stop.*/

            List<int[]> passengerList = new List<int[]> 
            {
                new[]{3,0},
                new[]{1,2},
                new[]{2,1},
                new[]{3,4},
                new[]{4,5},
            };

            Console.WriteLine(PeopleLeftOnTheBus(passengerList));

        }


        /*public static int PeopleLeftOnTheBus(List<int[]> peopleListInOut)
        {
            if(peopleListInOut is null) { return 0; }


            int peopleIn = 0;
            int peopleOut = 0;

            foreach (var element in peopleListInOut)
            {
                peopleIn += element[0];
                peopleOut += element[1];
            }

            int passengersAsleep = peopleIn - peopleOut;

            return passengersAsleep;

        }*/

        //A much more concise implementation using LINQ with null-conditional (?) and null-coalescing (??) operations
        //to safely return 0 in case the list is null:

        public static int PeopleLeftOnTheBus(List<int[]> peopleListInOut)
        {
            return peopleListInOut?.Sum(item => item[0] - item[1]) ?? 0;
        }




    }
}
