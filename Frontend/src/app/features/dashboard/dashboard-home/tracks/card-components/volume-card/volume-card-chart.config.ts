import { Guid } from 'guid-typescript';
import { backgroundColors, colorHelpers, fontColor, MyChartConfiguration } from 'src/app/shared/charts/chart.helpers';
import { Theme } from 'src/business/shared/theme.enum';
import { UnitSystem, UnitSystemUnitOfMeasurement } from 'src/server-models/enums/unit-system.enum';

export function GetVolumeCardChartConfig(
  setting: { theme: Theme, unitSystem: UnitSystem, mobile: boolean },
  data: number[],
  labels: string[]
): MyChartConfiguration {

  return {
    generationId: Guid.create(),
    type: 'line',
    data: {
      datasets: [
        {
          data,
          barThickness: 10,
          maxBarThickness: 20,
          fill: false,
          borderColor: backgroundColors(0, 1, setting.theme)[0],
          backgroundColor: backgroundColors(0, 1, setting.theme)[0],
        }
      ],
      labels
    },
    options: {
      responsive: true,
      maintainAspectRatio: false,
      tooltips: {
        mode: 'x',
        callbacks: {
          label: (tooltipItem, data) => {
            console.log(setting.unitSystem)
            return tooltipItem.yLabel + " " + UnitSystemUnitOfMeasurement[setting.unitSystem];
          }
        }
      },
      plugins: { labels: false },
      title: {
        display: false,
      },
      legend: {
        display: false
      },
      scales: {
        xAxes: [{
          ticks: {
            maxTicksLimit: setting.mobile ? 5 : 10,
            maxRotation: 0,
            fontColor: fontColor(setting.theme)
          },
          type: 'time',
          time: {
            minUnit: 'day',
          },
          gridLines: {
            color: colorHelpers(fontColor(setting.theme)).alpha(0.15).rgbString()
          }
        }],
        yAxes: [{
          ticks: {
            maxTicksLimit: setting.mobile ? 5 : 10,
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
