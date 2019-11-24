import { ChartConfiguration } from 'chart.js';

export function getTestPieChartConfig(): ChartConfiguration {
  return {
    type: 'pie',
    data: {
      datasets: [{
        data: [
          1,
          2,
          3,
          4,
          5,
        ],
        backgroundColor: [
          "#ff0000",
          "#ff8040",
          "#ffff00",
          "#00ff00",
          "#0000ff",
        ],
        label: 'Dataset 1'
      }],
      labels: [
        'Red',
        'Orange',
        'Yellow',
        'Green',
        'Blue'
      ]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false
    }
  };
}
