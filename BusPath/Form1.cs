using BusPath.BLL.Contracts;
using BusPath.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusPath
{
    public partial class Form1 : Form
    {
        private List<Schedule> schedules;
        private IRouteService routeService;

        public Form1(IRouteService routeService)
        {
            this.routeService = routeService;

            InitializeComponent();
        }

        private void filePathDialogButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filePathTextBox.Text) || !File.Exists(filePathTextBox.Text))
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    filePathTextBox.Text = openFileDialog.FileName;
            }

            try
            {
                schedules = routeService.GetScheduleFromFile(filePathTextBox.Text);
                var stopIds = routeService.GetBusStopIds(schedules).OrderBy(s => s).ToList();
                startStopListBox.DataSource = stopIds;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void startStopListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startStopListBox.SelectedItem != null)
            {
                var stops = routeService.GetEndBusStopIds(
                    schedules, (int)startStopListBox.SelectedItem).OrderBy(s => s).ToList();
                endStopListBox.DataSource = stops;
            }
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            var startTime = startTimeDateTimePicker.Value;
            var startStopId = (int)startStopListBox.SelectedItem;
            var endStopId = (int)endStopListBox.SelectedItem;

            var fastestBuses = routeService.GetFastestBusIdAndArrivalTime(
                startTime: startTime,
                schedules: schedules,
                startStopId: startStopId,
                endStopId: endStopId);

            var cheapestBuses = routeService.GetCheapestBusId(
                schedules: schedules,
                startStopId: startStopId,
                endStopId: endStopId);

            var resultText = new StringBuilder();

            if (fastestBuses.Count > 1)
                resultText.AppendLine("Fastest Buses:");
            else
                resultText.AppendLine("Fastest Bus:");

            fastestBuses.ForEach(bu => resultText.AppendLine(
                "Bus Number: "
                + bu.busId
                + ", Arrival Time: "
                + bu.arrivalTime.ToShortTimeString()));

            if (cheapestBuses.Count > 1)
                resultText.AppendLine("Cheapest Buses:");
            else
                resultText.AppendLine("Cheapest Bus:");

            cheapestBuses.ForEach(cu => resultText.AppendLine(
                "Bus Number: "
                + cu.busId
                + ", Price: "
                + cu.price));

            resultTextBox.Text = resultText.ToString();
        }
    }
}
