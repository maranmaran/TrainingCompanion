import { Theme } from 'src/business/shared/theme.enum';
import { MyChartConfiguration, backgroundColors, fontColor, colorHelpers } from 'src/app/shared/charts/chart.helpers';
import { Guid } from 'guid-typescript';
import { ChartData } from 'src/server-models/entities/chart-data';

export function getTotalVolumeIntensityChartConfig(theme: Theme, chartData: ChartData<number> ): MyChartConfiguration {
  
    return {
      generationId: Guid.create(),
      type: 'bar',
      data: {
        datasets: [
          {
            data: chartData.dataSets[0].data,
            barThickness: 10,
            maxBarThickness: 20,
            backgroundColor: backgroundColors(0, chartData.dataSets[0].data.length, theme),
          },
          {
            type: 'line',
            data: chartData.dataSets[1].data,
            fill: false,
            borderColor: backgroundColors(chartData.dataSets[0].data.length, chartData.dataSets[0].data.length + 1, theme)[0],
            backgroundColor: backgroundColors(chartData.dataSets[0].data.length, chartData.dataSets[0].data.length + 1, theme)[0],
          },
          {
            type: 'line',
            data: chartData.dataSets[2].data,
            fill: false,
            borderColor: backgroundColors(chartData.dataSets[0].data.length + 1, chartData.dataSets[0].data.length + 2, theme)[0],
            backgroundColor: backgroundColors(chartData.dataSets[0].data.length + 1, chartData.dataSets[0].data.length + 2, theme)[0],
          }
        ],
        labels: chartData.labels
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        legend: {
          display: false
        },
        hover: {
          mode: 'nearest',
          intersect: true
        },
        scales: {
          xAxes: [{
            display: true,
            scaleLabel: {
              display: true,
              fontColor: fontColor(theme)
            },
            ticks: {
              fontColor: fontColor(theme)
            },
            gridLines: {
              color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
            }
          }],
          yAxes: [{
            display: true,
            scaleLabel: {
              display: true,
              fontColor: fontColor(theme)
            },
            ticks: {
              maxTicksLimit: 6,
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