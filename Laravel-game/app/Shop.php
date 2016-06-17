<?php namespace App;


class Shop {

    /**
     * All equipments from the shop in an array
     *
     * @return array
     */
    public function buy()
    {

        return $shopArr = [
            ["type" => "Weapon", "name" => "Iron Hoe", "Damage" => "2", "price" => 3, "image" => "ironHoe.png"],
            ["type" => "Armor", "name" => "Wooden Shield", "Defense" => 10, "price" => 5, "image" => "woodenShield.png"],
            ["type" => "Charm", "name" => "Thors Snake Charm", "Luck" => 2, "price" => 2, "image" => "thorsSnakeCharm.png"],
            ["type" => "Weapon", "name" => "Sword", "Damage" => "4", "price" => 9, "image" => "kidsSword.png"],
        ];

    }

}