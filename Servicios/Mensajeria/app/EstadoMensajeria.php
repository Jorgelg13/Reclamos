<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class EstadoMensajeria extends Model
{
    protected $table = 'estado_mensajeria';
    protected $guarded = ['id'];
    public $timestamps = false;

    public function tracking()
    {
        return $this->hasMany('App\TrackingMensajeria', 'estado', 'id');
    }
}
