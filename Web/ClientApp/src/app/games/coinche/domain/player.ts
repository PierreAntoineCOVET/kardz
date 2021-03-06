import { Observable } from 'rxjs';
import { CardsEnum } from '../../../typewriter/enums/CardsEnum.enum';
import { ScreenCoordinate } from '../domain/PlayerPosition';
import { v4 as uuidv4 } from 'uuid';
import { StartTurnTimerEvent } from './events/turn-timer.event';

/**
 * Player responsible to display it's cards.
 */
export class Player {
    public number: number;
    public isDealer: boolean;
    public isPlaying: boolean;

    private readonly turnTimerBigSide = 300;
    private readonly turnTimerSmallSide = 30;

    constructor(public id: uuidv4, public position: ScreenCoordinate)
    {
    }

    /**
     * Set sceneElement position according to player position and card number.
     * @param index Card to display.
     * @param elementWidth Width of the elements (to aligne them).
     */
    public getSpritePosition(index: number, elementWidth: number): { x: number, y: number, angle: number } {
        const spritePosition = { x: 0, y: 0, angle: 0 };

        if (this.position == ScreenCoordinate.top) {
            spritePosition.x = 435 + (index * elementWidth);
            spritePosition.y = 86;
        }
        else if (this.position == ScreenCoordinate.bottom) {
            spritePosition.x = 435 + (index * elementWidth);
            spritePosition.y = 814;
        }
        else if (this.position == ScreenCoordinate.right) {
            spritePosition.x = 1514;
            spritePosition.y = 80 + (index * elementWidth);
            spritePosition.angle = 90;
        }
        else if (this.position == ScreenCoordinate.left) {
            spritePosition.x = 86;
            spritePosition.y = 80 + (index * elementWidth);
            spritePosition.angle = -90;
        }

        return spritePosition;
    }

    /**
     * Display the deal chip for the player who delt cards.
     */
    public getDealerChipPosition(): { x: number, y: number } {
        const spritePosition = { x: 0, y: 0 };

        if (this.position == ScreenCoordinate.top) {
            spritePosition.x = 430;
            spritePosition.y = 210;
        }
        else if (this.position == ScreenCoordinate.bottom) {
            spritePosition.x = 1150;
            spritePosition.y = 685;
        }
        else if (this.position == ScreenCoordinate.right) {
            spritePosition.x = 1390;
            spritePosition.y = 150;
        }
        else if (this.position == ScreenCoordinate.left) {
            spritePosition.x = 210;
            spritePosition.y = 730;
        }

        return spritePosition;
    }

    /**
     * Display the deal chip for the player who delt cards.
     */
    public getTurnTimerPosition(): StartTurnTimerEvent {
        const timerRectangle = new StartTurnTimerEvent();

        if (this.position == ScreenCoordinate.top) {
            timerRectangle.x = 930;
            timerRectangle.y = 210;
            timerRectangle.width = this.turnTimerBigSide;
            timerRectangle.height = this.turnTimerSmallSide;
            timerRectangle.direction = ScreenCoordinate.left;

        }
        else if (this.position == ScreenCoordinate.bottom) {
            timerRectangle.x = 650;
            timerRectangle.y = 685;
            timerRectangle.width = this.turnTimerBigSide;
            timerRectangle.height = this.turnTimerSmallSide;
            timerRectangle.direction = ScreenCoordinate.right;
        }
        else if (this.position == ScreenCoordinate.right) {
            timerRectangle.x = 1390;
            timerRectangle.y = 650;
            timerRectangle.width = this.turnTimerSmallSide;
            timerRectangle.height = this.turnTimerBigSide;
            timerRectangle.direction = ScreenCoordinate.top;
        }
        else if (this.position == ScreenCoordinate.left) {
            timerRectangle.x = 210;
            timerRectangle.y = 230;
            timerRectangle.width = this.turnTimerSmallSide;
            timerRectangle.height = this.turnTimerBigSide;
            timerRectangle.direction = ScreenCoordinate.bottom;
        }

        return timerRectangle;
    }
}

