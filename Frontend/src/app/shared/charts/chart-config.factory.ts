import { ChartConfiguration } from 'chart.js';
import { randomColor } from 'src/business/utils/utils';

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
          4,
        ],
        backgroundColor: [
          randomColor(),
          randomColor(),
          randomColor(),
          randomColor(),
          randomColor(),
        ],
        label: 'Dataset 1'
      }],
      labels: [
      ]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false
    }
  };
}

export function getTestBarChartConfig(): ChartConfiguration {
  return {
    type: 'bar',
    data: {
      datasets: [{
        data: [
          1,
          2,
          3,
          4,
          4,
        ],
        backgroundColor: [
          randomColor(),
          randomColor(),
          randomColor(),
          randomColor(),
          randomColor(),
        ],
        label: 'Dataset 1'
      }],
      labels: [
      ]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false
    }
  };
}

export function getTestLineChartConfig(): ChartConfiguration {
  return {
    type: 'line',
    data: {
      datasets: [{
        data: [
          1,
          2,
          3,
          4,
          4,
        ],
        backgroundColor: [
          randomColor(),
          randomColor(),
          randomColor(),
          randomColor(),
          randomColor(),
        ],
        label: 'Dataset 1'
      }],
      labels: [
      ]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false
    }
  };
}

