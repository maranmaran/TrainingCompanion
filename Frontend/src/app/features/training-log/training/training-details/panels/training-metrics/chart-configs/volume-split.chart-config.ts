import { Theme } from 'src/business/shared/theme.enum';
import { MyChartConfiguration, backgroundColors, fontColor } from 'src/app/shared/charts/chart.helpers';
import { Guid } from 'guid-typescript';

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
        legend: {
          position: 'top',
          labels: {
            fontColor: fontColor(theme)
          }
        },
      }
    };
  }
  