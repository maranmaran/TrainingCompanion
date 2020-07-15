import { Guid } from 'guid-typescript';
import { backgroundColors, colorHelpers, fontColor, MyChartConfiguration } from 'src/app/shared/charts/chart.helpers';
import { ChartDataSet } from 'src/server-models/entities/chart-data';
import { UnitSystemUnitOfMeasurement } from 'src/server-models/enums/unit-system.enum';
import { CardSettings } from '../models/card-params';

export function GetMaxCardChartConfig(
    setting: CardSettings,
    dataSets: ChartDataSet<number>[],
    labels: string[],
): MyChartConfiguration {

    var colors = backgroundColors(0, 3, setting.theme);
    var dataSetsObj = [];
    for (var i = 0; i < dataSets.length; i++) {
        dataSetsObj.push({
            data: dataSets[i].data,
            barThickness: 10,
            maxBarThickness: 20,
            fill: false,
            borderColor: colors[i],
            backgroundColor: colors[i],
        });
    }

    return {
        generationId: Guid.create(),
        type: 'line',
        data: {
            datasets: dataSetsObj,
            labels
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: { labels: false },
            tooltips: {
                mode: 'x',
                callbacks: {
                    label: (tooltipItem, data) => {
                        console.log(setting.unitSystem)
                        return tooltipItem.yLabel + " " + UnitSystemUnitOfMeasurement[setting.unitSystem];
                    }
                }
            },
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
