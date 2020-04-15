import { ChartConfiguration } from 'chart.js';
import { MyChartConfiguration, backgroundColors, fontColor, colorHelpers } from 'src/app/shared/charts/chart.helpers';
import { Guid } from 'guid-typescript';
import { UnitSystemUnitOfMeasurement } from 'src/server-models/enums/unit-system.enum';
import { Theme } from 'src/business/shared/theme.enum';

export function getLineChartPreviewConfig(theme: Theme): MyChartConfiguration {

    return {
        generationId: Guid.create(),
        type: 'line',
        data: {
            datasets: [
                {
                    data: [0, 1, 0, 1], // fake data for preview
                    barThickness: 40,
                    fill: false,
                    borderColor: backgroundColors(0, 1, theme)[0],
                    backgroundColor: backgroundColors(0, 1, theme)[0],
                }
            ],
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: { labels: false },
            title: { display: false },
            legend: { display: false },
            hover: { mode: null },
            tooltips: { enabled: false },
            scales: {
                display: false,
                gridLines: {
                    display: true,
                    drawBorder: false
                },
                xAxes: [
                    {
                        gridLines: {
                            drawOnChartArea: false,
                        },
                        // gridLines: { display: false, drawBorder: true },
                        // scaleLabel: { display: false },
                        ticks: { display: false }
                    }
                ],
                yAxes: [
                    {
                        gridLines: {
                            drawOnChartArea: false,
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