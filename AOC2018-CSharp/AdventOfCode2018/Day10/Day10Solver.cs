using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace AdventOfCode2018.Day10
{
    public class Day10Solver
    {
        private static string TESTDATAFILE = "AdventOfCode2018.Day10.testdata.txt";
        private static string DATAFILE = "AdventOfCode2018.Day10.data.txt";

        private List<PointData> _pointData;
        private List<String> _loadedData = null;

        public Point Normalizer { get; set; }
        public int LoadedDataCount { get { return _loadedData.Count; } }
        public int LoadedPointDataCount { get { return _pointData.Count; } }

        // --------------------------------------------------------------------
        public void Reset()
        {
            if (_pointData != null)
                _pointData.Clear();

            _pointData = null;

            if( _loadedData != null)
                _loadedData.Clear();

            _loadedData = null;
        }

        // --------------------------------------------------------------------
        public IEnumerable<Point> SolveNext()
        {
            if (_pointData == null)
                throw new InvalidOperationException("No point data has been loaded before calling solve next.");

            var data = new List<Point>();

            foreach (var dp in _pointData)
            {
                dp.CalculateNextPosition();
                data.Add(dp.NormalizeLocation(Normalizer));
            }

            return data;
        }

        // --------------------------------------------------------------------
        public void ParseLoadedDataIntoPointCollection()
        {
            if (_loadedData == null)
                throw new ArgumentException("Parse loaded data called before data file was loaded.");

            _pointData = new List<PointData>(_loadedData.Count);
            foreach (var line in _loadedData)
            {
                var points = GeneratesPointPairsFromDataLine(line);
                _pointData.Add(new PointData(points));
            }
        }

        // --------------------------------------------------------------------
        private Point[] GeneratesPointPairsFromDataLine(String line)
        {
            var points = new Point[2];
            var segments = line.Split(new string[] { " velocity" }, StringSplitOptions.RemoveEmptyEntries);

            points[0] = GeneratePointFromSegment(segments[0]);
            points[1] = GeneratePointFromSegment(segments[1]);

            return points;
        }

        // --------------------------------------------------------------------
        private Point GeneratePointFromSegment(String segment)
        {
            var s = segment.Substring(segment.IndexOf("<"));
            var data = s.Replace("<", String.Empty).Replace(">", String.Empty).Trim().Split(',');

            return new Point(int.Parse(data[0]), int.Parse(data[1]));
        }

        // --------------------------------------------------------------------
        public void LoadProductionData()
        {
            _loadedData = new List<String>(LoadData(DATAFILE));
            ParseLoadedDataIntoPointCollection();
        }

        // --------------------------------------------------------------------
        public void LoadTestData()
        {
            _loadedData = new List<String>(LoadData(TESTDATAFILE));
            ParseLoadedDataIntoPointCollection();
        }

        // --------------------------------------------------------------------
        private IEnumerable<String> LoadData(String resource)
        {
            return (this.ReadResource(resource))
                .Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
        }

        // --------------------------------------------------------------------
        protected String ReadResource(string resource)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resource))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    public class PointData
    {
        public PointData(Point[] data)
        {
            Location = data[0];
            Velocity = data[1];
        }

        public Point Location { get; set; }
        
        public Point Velocity { get; set; }

        public void CalculateNextPosition()
        {
            int newX = Location.X + Velocity.X;
            int newY = Location.Y + Velocity.Y;

            Location = new Point(newX, newY);
        }

        public Point NormalizeLocation(Point normalizer)
        {
            int originX = normalizer.X / 2;
            int originY = normalizer.Y / 2;

            int normalizedX = ((Location.X) + originX);
            int normalizedY = ((-(Location.Y) + originY));

            return new Point(normalizedX, normalizedY);
        }
    }
}
