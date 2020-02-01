import * as Chart from 'chart.js';
import { ChartConfiguration } from 'chart.js';
import { Guid } from 'guid-typescript';
import { Theme } from '../../../business/shared/theme.enum';

export const chartColorsLightTheme = {
  red: 'rgb(255, 99, 132)',
  orange: 'rgb(255, 159, 64)',
  yellow: 'rgb(255, 205, 86)',
  green: 'rgb(75, 192, 192)',
  blue: 'rgb(54, 162, 235)',
  purple: 'rgb(153, 102, 255)',
  grey: 'rgb(231,233,237)'
};

export const chartColorsDarkTheme = {
  blue: 'rgb(54, 162, 235)',
  purple: 'rgb(153, 102, 255)',
  red: 'rgb(255, 99, 132)',
  orange: 'rgb(255, 159, 64)',
  yellow: 'rgb(255, 205, 86)',
  green: 'rgb(75, 192, 192)',
  grey: 'rgb(231,233,237)'
};
export const getChartColors = (theme: Theme) => theme == Theme.Dark ? chartColorsDarkTheme : chartColorsLightTheme;

export const colorsArr = (theme: Theme): string[] => Object.values(getChartColors(theme));
export const backgroundColors = (from, to, theme) => colorsArr(theme).slice(from, to);
export const fontColor = (theme: Theme) => theme == Theme.Dark ? 'white' : 'black';
export const colorHelpers = Chart.helpers.color;

export interface MyChartConfiguration extends ChartConfiguration {
  generationId: Guid
}


export function getLineChartConfig(theme: Theme, data: number[], labels: string[]): MyChartConfiguration {
  return {
    generationId: Guid.create(),
    type: 'line',
    data: {
      datasets: [
        {
          data,
        }
      ],
      labels
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      legend: {
        position: 'top',
        labels: {
          fontColor: fontColor(theme)
        }
      },
      scales:  {
        xAxes: [{
          ticks: {
            fontColor: fontColor(theme)
          },
          gridLines: {
            color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
          }
        }],
        yAxes: [{
          ticks: {
            fontColor: fontColor(theme)
          },
          gridLines: {
            color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
          }
        }]
      }
    }
  };
}

export function getHorizontalChartConfig(theme: Theme, data: number[], labels: string[]): MyChartConfiguration {
  return {
    generationId: Guid.create(),
    type: 'horizontalBar',
    data: {
      datasets: [{
        data,
        backgroundColor: backgroundColors(0, data.length, theme),
        barThickness: 10,
        maxBarThickness: 20,
      }],
      labels
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      legend: {
        display: false
      },
      scales: {
        xAxes: [{
          ticks: {
            beginAtZero: true,
            fontColor: fontColor(theme)
          },
          gridLines: {
            color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
          }
        }],
        yAxes: [{
          ticks: {
            fontColor: fontColor(theme)
          },
          gridLines: {
            color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
          }
        }]
      }
    }
  };
}

export function getHorizontalStackedChartConfig(theme: Theme, data: number[], labels: string[]): MyChartConfiguration {
  return {
    generationId: Guid.create(),
    type: 'horizontalBar',
    data: {
      datasets: [
        {
          data,
          backgroundColor: backgroundColors(0, data.length, theme),
          barThickness: 10,
          maxBarThickness: 20
        },
        {
          data,
          backgroundColor: backgroundColors(data.length, data.length*2, theme),
          barThickness: 10,
          maxBarThickness: 20,
        }
      ],
      labels
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      legend: {
        display: false
      },
      scales: {
        xAxes: [{
          stacked: true,
          ticks: {
            fontColor: fontColor(theme)
          },
          gridLines: {
            color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
          }
        }],
        yAxes: [{
          stacked: true,
          ticks: {
            fontColor: fontColor(theme)
          },
          gridLines: {
            color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
          }
        }]
      },
    }
  };
}

export function getPolarAreaChart(theme: Theme, data: number[], labels: string[]): MyChartConfiguration {
  return {
    generationId: Guid.create(),
    type: 'polarArea',
    data: {
      datasets: [{
        data,
        backgroundColor: backgroundColors(0, data.length, theme),
      }],
      labels
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      legend: {
        position: 'top',
        labels: {
          fontColor: fontColor(theme)
        }
      },
      scale: {
        ticks: {
          display: false
        }
      }
    }
  };
}


