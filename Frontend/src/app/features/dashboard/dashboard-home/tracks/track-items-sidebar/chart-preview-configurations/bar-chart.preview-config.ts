import { ChartConfiguration } from 'chart.js';
import { Guid } from 'guid-typescript';
import { backgroundColors, colorHelpers, fontColor, MyChartConfiguration } from 'src/app/shared/charts/chart.helpers';
import { Theme } from 'src/business/shared/theme.enum';

export function getBarChartPreviewConfig(theme: Theme): MyChartConfiguration {
    // fake data for preview
    const data = [3, 2, 4, 1, 0];

    return {
        generationId: Guid.create(),
        type: 'bar',
        data: {
            datasets: [
                {
                    data,
                    barThickness: 20,
                    borderWidth: 6,
                    fill: false,
                    borderColor: backgroundColors(0, 4, theme),
                    backgroundColor: backgroundColors(0, 4, theme),
                }
            ],
            labels: [1, 2, 3, 4]
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
            maintainAspectRatio: true,
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