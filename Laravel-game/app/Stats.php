<?php namespace App;

use Illuminate\Database\Eloquent\Model;

class Stats extends Model {

    /**
     * The database table used by the model.
     *
     * @var string
     */
    protected $table = 'stats';

	protected $fillable = ['user_id', 'damage', 'health', 'gold', 'xp'];

    /**
     * User can have many stats
     * @return \Illuminate\Database\Eloquent\Relations\BelongsTo
     */
    public function user()
    {
        return $this->belongsTo('App\User');
    }

}
