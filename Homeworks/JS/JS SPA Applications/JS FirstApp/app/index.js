(function () {
	var count,
		forArray = {},
		againstArray = {},
		forValue,
		againstValue,
		titleValue,
		forText,
		againstText,
		i, len,
		node,
		result,
		strongNode,
		closeButton,
		index;

	count = 0;

	function CreateElement() {
		forValue = $("#for-input").val().trim();
		againstValue = $("#against-input").val().trim();
		titleValue = $('#title-input').val().trim();

		if (forValue[forValue.length - 1] == '%') {
			result = '';
			for (i = 0, len = forValue.length - 2; i <= len; i += 1) {
				result += forValue[i];
			}

			forValue = result;
		}

		if (titleValue[0] == '"') {
			result = '';
			for (i = 1, len = titleValue.length - 1; i <= len; i += 1) {
				result += titleValue[i];
			}

			titleValue = result;
		}

		if (titleValue[titleValue.length - 1] == '"') {
			result = '';
			for (i = 0, len = titleValue.length - 2; i <= len; i += 1) {
				result += titleValue[i];
			}

			titleValue = result;
		}

		if (againstValue[againstValue.length - 1] == '%') {
			result = '';
			for (i = 0, len = againstValue.length - 2; i <= len; i += 1) {
				result += againstValue[i];
			}

			againstValue = result;
		}

		forValue = +forValue;
		againstValue = +againstValue;

		if (typeof (forValue) != 'number') {
			InvalidInput();
			return;
		}

		if (typeof (againstValue) != 'number') {
			InvalidInput();
			return;
		}

		if (forValue < 0 || forValue > 100 || againstValue < 0 || againstValue > 100) {
			InvalidInput();
			return;
		}

		if (forValue + againstValue != 100) {
			InvalidInput();
			return;
		}

		forArray[count] = (forValue);
		againstArray[count] = (againstValue);

		forText = forValue + '%';
		againstText = againstValue + '%';

		node = $('<li/>').addClass(count).attr('id', count);

		strongNode = ('Мит: <strong>„' + titleValue + '“</strong>, ');

		closeButton = $('<a/>').attr('href', '#').addClass('glyphicon glyphicon-remove delete-button').attr('style', "color:darkred").attr('id', count);

		closeButton.on('click', function (ev) {
			$('#' + ev.target.id).remove();
			delete forArray[ev.target.id];
			delete againstArray[ev.target.id];
			CalculateAverage();
		});

		if (titleValue == '') {
			$("<h3/>").addClass("output").html('Истина: ' + forText + ', Лъжа: ' + againstText).append(closeButton).appendTo(node);
		} else {
			$("<h3/>").addClass("output").html(strongNode + 'Истина: ' + forText + ', Лъжа: ' + againstText + '       ').append(closeButton).appendTo(node);
		}
		node.prependTo('#append');

		CalculateAverage();
		count += 1;
	}

	$("#submit").on('click', CreateElement)

	var InvalidInput = function () {
		toastr.error('Невалидни данни!')
	}

	var CalculateAverage = function () {
		result = 0;
		index = 0;

		for (var key in forArray) {
			result += forArray[key];
			index += 1;
		}

		result = result / index;

		$('#for-output').html(Math.round(result * 100) / 100);

		result = 0;

		for (var key in againstArray) {
			result += againstArray[key];
		}

		result = result / index;

		$('#against-output').html(Math.round(result * 100) / 100);
	}

} ());