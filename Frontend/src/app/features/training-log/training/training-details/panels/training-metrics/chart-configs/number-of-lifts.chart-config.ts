import { Guid } from 'guid-typescript';
import { backgroundColors, colorHelpers, fontColor, MyChartConfiguration } from 'src/app/shared/charts/chart.helpers';
import { Theme } from 'src/business/shared/theme.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';



export function getNumberOfLiftsChartConfig(
    setting: {theme: Theme, unitSystem: UnitSystem},
    data: number[],
    labels: string[]
): MyChartConfiguration {

    return {
      generationId: Guid.create(),
      type: 'bar',
      data: {
        datasets: [
          {
            data,
            barThickness: 10,
            maxBarThickness: 20,
            backgroundColor: backgroundColors(0, 1, setting.theme)[0],
          }
        ],
        labels
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          labels:
            {
              render: 'value',
              fontColor: fontColor(setting.theme),
            }
        },
        tooltips: {
          callbacks: {
            label: (tooltipItem, data) => {
              return tooltipItem.yLabel + ' lifts';
            }
          }
        },
        title: {
          display: true,
          fontColor: fontColor(setting.theme),
          text: 'Number of lifts',
          fontSize: 15
        },
        legend: {
          display: false
        },
        scales: {
          xAxes: [{
            ticks: {
              fontColor: fontColor(setting.theme)
            },
            gridLines: {
              color: colorHelpers(fontColor(setting.theme)).alpha(0.15).rgbString()
            }
          }],
          yAxes: [{
            ticks: {
              beginAtZero: true,
              fontColor: fontColor(setting.theme)
            },
            gridLines: {
              color: colorHelpers(fontColor(setting.theme)).alpha(0.15).rgbString()
            }
          }]
        }
      }
    };
  }
