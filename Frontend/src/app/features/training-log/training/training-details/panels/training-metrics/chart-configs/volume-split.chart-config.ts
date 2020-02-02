import { Guid } from 'guid-typescript';
import { backgroundColors, fontColor, MyChartConfiguration } from 'src/app/shared/charts/chart.helpers';
import { Theme } from 'src/business/shared/theme.enum';
import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

export function getVolumeSplitChartConfig(setting: {theme: Theme, unitSystem: UnitSystem}, data: number[], labels: string[]): MyChartConfiguration {

    return {
      generationId: Guid.create(),
      type: 'pie',
      data: {
        datasets: [{
          data,
          backgroundColor: backgroundColors(0, data.length, setting.theme),
        }],
        labels
      },
      options: {
        responsive: true,
        maintainAspectRatio: false,
        plugins: {
          labels: [
            {
              render: 'percentage',
              fontColor: fontColor(setting.theme),
              precision: 2
            }
          ]
        },
        title: {
          display: true,
          fontColor: fontColor(setting.theme),
          text: 'Volume split',
          fontSize: 15
        },
        legend: {
          position: 'top',
          labels: {
            fontColor: fontColor(setting.theme)
          }
        },
      }
    };
  }
