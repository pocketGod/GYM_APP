import { trigger, transition, query, style, stagger, animate, state } from "@angular/animations";

export const slideDown = trigger('slideDown', [
  transition('* <=> *', [
    query(':enter, :leave', [
      style({ transform: 'translateY(-100%)', opacity: 0 }),
    ], { optional: true }),
    query(':enter', [
      stagger('300ms', [
        animate('300ms ease-in', style({ transform: 'translateY(0%)', opacity: 1 }))
      ])
    ], { optional: true })
  ])
]);

export const slideInOut = trigger('slideInOut', [
  state('in', style({ transform: 'translateX(0)', opacity: 1 })),
  state('void', style({ transform: 'translateX(100%)', opacity: 0 })),
  transition(':enter', [
    style({ transform: 'translateX(100%)', opacity: 0 }),
    animate('300ms ease-in', style({ transform: 'translateX(0)', opacity: 1 }))
  ]),
  transition(':leave', [
    animate('300ms ease-in', style({ transform: 'translateX(100%)', opacity: 0 }))
  ])
]);
