import { Guid } from 'guid-typescript';
import { backgroundColors, colorHelpers, fontColor, MyChartConfiguration } from 'src/app/shared/charts/chart.helpers';
import { Theme } from 'src/business/shared/theme.enum';

export function getLineChartPreviewConfig(theme: Theme): MyChartConfiguration {

    // fake data for preview
    const data = [0, 100, 0, 100];

    return {
        generationId: Guid.create(),
        type: 'line',
        data: {
            datasets: [
                {
                    data,
                    barThickness: 20,
                    borderWidth: 6,
                    fill: false,
                    borderColor: backgroundColors(0, 1, theme)[0],
                    backgroundColor: backgroundColors(0, 1, theme)[0],
                }
            ],
            labels: [0, 1, 2, 3]
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
            scales: {
                xAxes: [
                    {
                        gridLines: {
                            display: false,
                            color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
                        },
                        // gridLines: { display: false, drawBorder: true },
                        // scaleLabel: { display: false },
                        ticks: { display: false }
                    }
                ],
                yAxes: [
                    {
                        gridLines: {
                            display: false,
                            color: colorHelpers(fontColor(theme)).alpha(0.15).rgbString()
                        },
                        // gridLines: { display: false, drawBorder: true },
                        // scaleLabel: { display: false },
                        ticks: { display: false }
                    }
                ]
            }
        }
    };
}
