import { Guid } from 'guid-typescript';
import { backgroundColors, fontColor, MyChartConfiguration } from 'src/app/shared/charts/chart.helpers';
import { Theme } from 'src/business/shared/theme.enum';

export function getVolumeSplitChartConfig(theme: Theme, data: number[], labels: string[]): MyChartConfiguration {

    return {
      generationId: Guid.create(),
      type: 'pie',
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
        title: {
          display: true,
          fontColor: fontColor(theme),
          text: 'Volume split',
          fontSize: 15
        },
        legend: {
          position: 'top',
          labels: {
            fontColor: fontColor(theme)
          }
        },
      }
    };
  }
