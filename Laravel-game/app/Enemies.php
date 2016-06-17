<?php namespace App;


class Enemies {

    /**
     * All enemies from raid in an array
     *
     * @return array
     */
    public function getEnemy()
    {

        return $enemyArr = [
            [],
            ["name" => "Lonely Traveller", "damage" => 12, "health" => 5, "luck" => 5, "image" => "lonelyTraveler.png"],
            ["name" => "Lost Knight", "damage" => 11, "health" => 100, "luck" => 6, "image" => "saxonKnight.png"],
            ["name" => "Harmless Joker", "damage" => 13, "health" => 100, "luck" => 2, "image" => "sillyJoker.png"],
            ["name" => "Lonely Traveller V2", "damage" => 12, "health" => 5, "luck" => 5, "image" => "lonelyTraveler.png"],
            ["name" => "Lost Knight V2", "damage" => 11, "health" => 100, "luck" => 6, "image" => "saxonKnight.png"],
        ];

    }
}