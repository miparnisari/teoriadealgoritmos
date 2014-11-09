using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TP2.Model;

namespace TP2
{
    public abstract class BaseScenarioReader
    {
        public abstract Stream Stream
        {
            get;
        }


        public void Read(ref List<City> cities, ref List<Train> trains, ref Request request)
        {
            bool success;

            // open the file
            using (var stream = Stream)
            {
                using (var reader = new StreamReader(stream))
                {
                    int numberOfCities;
                    success = Int32.TryParse(reader.ReadLine(), out numberOfCities);

                    if (success)
                    {
                        Debug.Assert(numberOfCities >= 2, "Need more than two cities");
                        ReadCities(cities, reader, numberOfCities);
                    }

                    int numberOfTrains;
                    success = Int32.TryParse(reader.ReadLine(), out numberOfTrains);

                    if (success)
                    {
                        for (int trainId = 1; trainId <= numberOfTrains; trainId++)
                        {
                            var train = new Train(trainId);

                            int numberOfCitiesVisitedByTrain;
                            success = Int32.TryParse(reader.ReadLine(), out numberOfCitiesVisitedByTrain);

                            if (success)
                            {
                                Debug.Assert(numberOfCitiesVisitedByTrain >= 2, "A train should visit more than one city");
                                ReadTrainSchedule(reader, train, numberOfCitiesVisitedByTrain);

                                trains.Add(train);
                            }
                        }
                        request.StartTime = DateTime.Parse(reader.ReadLine().Insert(2, ":"));
                        request.Origin = new City(reader.ReadLine().Trim());
                        request.Destination = new City(reader.ReadLine().Trim());
                    }
                }
            }
        }

        private static void ReadTrainSchedule(StreamReader reader, Train train, int numberOfCitiesVisitedByTrain)
        {
            int numberOfRoutes = numberOfCitiesVisitedByTrain - 1; // for two cities there is one route

            string[] line = reader.ReadLine().Insert(2, ":").Split(' ');
            DateTime startTimeRoute = DateTime.Parse(line[0]);
            City originRoute = new City(line[1]);

            for (int i = 0; i < numberOfRoutes; i += 1)
            {
                line = reader.ReadLine().Insert(2, ":").Split(' ');
                DateTime endTimeRoute = DateTime.Parse(line[0]);
                City destinationRoute = new City(line[1]);

                var route = new Route
                {
                    DepartTime = startTimeRoute,
                    ArrivalTime = endTimeRoute,
                    Origin = originRoute,
                    Destination = destinationRoute
                };

                train.Routes.Add(route);

                startTimeRoute = endTimeRoute;
                originRoute = destinationRoute;
            }
        }

        private static void ReadCities(List<City> cities, StreamReader reader, int numberOfCities)
        {
            for (int i = 0; i < numberOfCities; i++)
            {
                cities.Add(new City(reader.ReadLine()));
            }
        }
    }
}
