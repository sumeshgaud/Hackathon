
var AlphaChart = function (config) {
    this.config = {
        data: config.data,
        totalItemCount: 0,
        type: config.type || null,
        id: config.id || '',
        container: config.container || '',        
        onRender: config.onRender || null,
        caption: config.caption || null,
        subCaption: config.subCaption || null
    };

    this.render = function () {

        if (FusionCharts(this.config.id))
            FusionCharts(this.config.id).dispose();

        var chart = new FusionCharts(this.config.type, this.config.id);

        chart.setJSONData({
            "chart":
                {
                    "caption": this.config.caption,
                    "subCaption": this.config.subCaption,
                    "xAxisName": "",
                    "yAxisName": "",
                    "numberPrefix": "",
                    "theme": "fint"
                },
            "data": this.config.data
        });


        chart.render(document.getElementById(this.config.container));

        if (this.config.onRender != null) {
            $(this).trigger(this.config.onRender(this));
        }
    };

    this.reload = function (result) {

        var me = this;        

        me.config.data = result.data;
        me.config.totalItemCount = result.TotalItemCount;
        me.render();                   
    };
};

