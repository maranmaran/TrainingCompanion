import { Guid } from 'guid-typescript';
import { backgroundColors, colorHelpers, fontColor, MyChartConfiguration } from 'src/app/shared/charts/chart.helpers';
import { Theme } from 'src/business/shared/theme.enum';



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
            backgroundColor: backgroundColors(0, 1, theme)[0],
          }
        ],
        labels
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        title: {
          display: true,
          fontColor: fontColor(theme),
          text: 'Number of lifts',
          fontSize: 15
        },
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
