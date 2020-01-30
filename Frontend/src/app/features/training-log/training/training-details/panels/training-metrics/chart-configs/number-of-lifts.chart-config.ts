import { Theme } from 'src/business/shared/theme.enum';

import { MyChartConfiguration, backgroundColors, fontColor, colorHelpers } from 'src/app/shared/charts/chart.helpers';

import { Guid } from 'guid-typescript';

export function getNumberOfLiftsChartConfig(theme: Theme, data: number[], labels: string[]): MyChartConfiguration {
    return {
      generationId: Guid.create(),
      type: 'bar',
      data: {
        datasets: [
          {
            data,
            barThickness: 10,
            maxBarThickness: 20,
            backgroundColor: backgroundColors(0, data.length, theme),
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
            ticks: {
              fontColor: fontColor(theme)
            },
            gridLines: {
              color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
            }
          }],
          yAxes: [{
            ticks: {
              beginAtZero: true,
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