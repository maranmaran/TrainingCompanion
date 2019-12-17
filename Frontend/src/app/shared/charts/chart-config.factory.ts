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
      datasets: [
        {
          data: [1, 2, 3, 4, 4,],
          label: 'Dataset 1',
          barThickness: 10,
          maxBarThickness: 20,
          backgroundColor: [
            randomColor(),
            randomColor(),
            randomColor(),
            randomColor(),
            randomColor(),
          ],
        }
      ],
      labels: [
        "1", "2", "3", "4", "4"
      ]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      scales: {
        xAxes: [{
          ticks: {
            beginAtZero: true
          }
        }],
      }
    }
  };
}

export function getTestLineChartConfig(): ChartConfiguration {
  return {
    type: 'line',
    data: {
      datasets: [
        {
          data: [1, 2, 3, 4, 4,],
          label: 'Dataset 1',
        }
      ],
      labels: [
        "1", "2", "3", "4", "4"
      ]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
    }
  };
}

export function getTestHorizontalChartConfig(): ChartConfiguration {
  return {
    type: 'horizontalBar',
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
        barThickness: 10,
        maxBarThickness: 20,
        label: 'Dataset 1'
      }],
      labels: [
      ]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      scales: {
        xAxes: [{
          ticks: {
            beginAtZero: true
          }
        }],
      }
    }
  };
}

export function getTestPolarAreaChart(): ChartConfiguration {
  return {
    type: 'polarArea',
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

export function getTestHorizontalStackedChartConfig(): ChartConfiguration {
  return {
    type: 'horizontalBar',
    data: {
      datasets: [
        {
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
          barThickness: 10,
          maxBarThickness: 20,
          label: 'Dataset 1'
        },
        {
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
          barThickness: 10,
          maxBarThickness: 20,
          label: 'Dataset 2'
        }
      ],
      labels: [
      ]
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      scales: {
        xAxes: [{
          stacked: true
        }],
        yAxes: [{
          stacked: true
        }]
      }
    }
  };
}
