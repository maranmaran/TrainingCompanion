import { Guid } from 'guid-typescript';
import { backgroundColors, colorHelpers, fontColor, MyChartConfiguration } from 'src/app/shared/charts/chart.helpers';
import { Theme } from 'src/business/shared/theme.enum';
import { ChartData } from 'src/server-models/entities/chart-data';
import { UnitSystem, UnitSystemUnitOfMeasurement } from 'src/server-models/enums/unit-system.enum';

export function getTotalVolumeIntensityChartConfig(setting: {theme: Theme, unitSystem: UnitSystem}, chartData: ChartData<number>,): MyChartConfiguration {

    return {
      generationId: Guid.create(),
      type: 'bar',
      data: {
        datasets: [
          {
            type: 'line',
            label: 'PEAK intensity',
            data: chartData.dataSets[2].data,
            fill: false,
            borderColor: backgroundColors(2, 3, setting.theme)[0],
            backgroundColor: backgroundColors(2, 3, setting.theme)[0],
          },
          {
            type: 'line',
            label: 'AVG intensity',
            data: chartData.dataSets[1].data,
            fill: false,
            borderColor: backgroundColors(1, 2, setting.theme)[0],
            backgroundColor: backgroundColors(1, 2, setting.theme)[0],
          },
          {
            label: 'Total volume',
            data: chartData.dataSets[0].data,
            barThickness: 10,
            maxBarThickness: 20,
            backgroundColor: backgroundColors(0, 1, setting.theme)[0],
          },
        ],
        labels: chartData.labels
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          labels: {
              render: 'value',
              fontColor: fontColor(setting.theme),
            }
        },
        tooltips: {
          callbacks: {
            label: (tooltipItem, data) => {
              if(tooltipItem.datasetIndex == 0 || tooltipItem.datasetIndex == 1)
                return tooltipItem.yLabel + ' %';

              return tooltipItem.yLabel + UnitSystemUnitOfMeasurement[setting.unitSystem];
            }
          }
        },
        title: {
          display: true,
          fontColor: fontColor(setting.theme),
          text: 'Total volume with AVG intensity and PEAK intensity',
          fontSize: 15
        },
        legend: {
          display: true,
          labels: {
            fontColor: fontColor(setting.theme)
          }
        },
        hover: {
          // mode: 'nearest',
          // intersect: true
        },
        scales: {
          xAxes: [{
            display: true,
            scaleLabel: {
              display: true,
              fontColor: fontColor(setting.theme)
            },
            ticks: {
              fontColor: fontColor(setting.theme)
            },
            gridLines: {
              color: colorHelpers(fontColor(setting.theme)).alpha(0.15).rgbString()
            }
          }],
          yAxes: [{
            display: true,
            scaleLabel: {
              display: true,
              fontColor: fontColor(setting.theme)
            },
            ticks: {
              maxTicksLimit: 6,
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
