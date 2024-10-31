from flask import Flask, request, jsonify, send_file
from transformers import AutoModelForCausalLM, AutoTokenizer
from TTS.api import TTS
import os

app = Flask(_name_)

# Load Qwen-7B model
model_name = "qwen/Qwen-7B"
tokenizer = AutoTokenizer.from_pretrained(model_name)
model = AutoModelForCausalLM.from_pretrained(model_name)

# Load Mozilla TTS
tts = TTS(model_name="tts_models/en/ljspeech/tacotron2-DDC", progress_bar=True, gpu=False)

@app.route('/generate', methods=['POST'])
def generate():
    prompt = request.json.get("prompt")

    # Generate text with Qwen-7B model
    inputs = tokenizer(prompt, return_tensors="pt")
    outputs = model.generate(**inputs, max_length=50)
    generated_text = tokenizer.decode(outputs[0], skip_special_tokens=True)

    # Convert text to speech
    audio_file_path = "output.wav"
    tts.tts_to_file(text=generated_text, file_path=audio_file_path)

    # Return the audio file as a response
    return send_file(audio_file_path, as_attachment=True)

if _name_ == '_main_':
    app.run(debug=True)
