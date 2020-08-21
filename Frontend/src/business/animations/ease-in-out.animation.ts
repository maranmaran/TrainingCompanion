import { animate, group, query, style, transition, trigger } from '@angular/animations';

// Fade Animation
export const easeInOut = trigger('easeInOut', [
    transition('* => *', [

        // reset route
        style({ position: 'relative' }),
        query(
            ':enter, :leave',
            [
                style({
                    position: 'absolute', // remark: using absolute makes the scroll get stuck in the previous page's scroll position on the new page
                    width: '100%',
                    opacity: 0,
                }),
            ],
            { optional: true }
        ),

        // prepare first element
        query(':enter',
            [
                style({ opacity: 0 })
            ],
            { optional: true }
        ),

        // do simultaneous animations for elements coming and and coming out via group
        // group does both animations in parallel
        group([

            query(':leave',
                [
                    // fade out animation
                    // style({ opacity: 1 }), 
                    // animate('0s', style({ opacity: 0 }))

                    style({ opacity: 0 }) // remove leaving component instantly
                ],
                { optional: true }
            ),

            query(':enter',
                [
                    // fade in animation
                    style({ opacity: 0 }),
                    animate('0.4s', style({ opacity: 1 }))
                ],
                { optional: true }
            )

        ])

    ]),
]);
