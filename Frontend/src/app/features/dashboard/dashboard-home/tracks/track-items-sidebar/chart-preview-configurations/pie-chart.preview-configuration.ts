import { Theme } from 'src/business/shared/theme.enum';
import { MyChartConfiguration, backgroundColors, colorHelpers, fontColor } from 'src/app/shared/charts/chart.helpers';
import { Guid } from 'guid-typescript';

export function getPieChartPreviewConfig(theme: Theme): MyChartConfiguration {

    // fake data for preview
    const data = [25, 15, 60];

    return {
        generationId: Guid.create(),
        type: 'pie',
        data: {
            datasets: [
                {
                    data,
                    backgroundColor: backgroundColors(0, data.length, theme),
                }
            ],
            labels: [0, 1, 2]
        },
        options: {
            layout: {
                padding: {
                    top: 10,
                    right: 10,
                    left: 10,
                    bottom: 10
                }
            },
            responsive: true,
            maintainAspectRatio: false,
            plugins: { labels: false },
            title: { display: false },
            legend: { display: false },
            hover: { mode: null },
            tooltips: { enabled: false },
        }
    };
}