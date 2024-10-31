# AI-Powered Talking Avatar System

An advanced system that combines AI text generation with speech synthesis to create an interactive 3D avatar. The system uses Qwen-7B for text generation and Mozilla TTS for speech synthesis, rendered through a Unity-based 3D avatar interface.

## 🌟 Features

- Real-time text generation using Qwen-7B
- High-quality speech synthesis with Mozilla TTS
- 3D avatar with lip-sync and emotional expressions
- Optimized performance with GPU acceleration
- Scalable API architecture
- Comprehensive error handling and logging

## 🚀 Quick Start

### Prerequisites

- Python 3.8+
- CUDA-capable GPU (recommended)
- Unity 2021.3 LTS or newer
- Docker and Docker Compose (for containerized deployment)

### Backend Setup

1. Clone the repository:
```bash
git clone https://github.com/yourusername/talking-avatar-project.git
cd talking-avatar-project
```

2. Using Docker (Recommended):
```bash
docker-compose up --build
```

3. Manual Setup:
```bash
# Create virtual environment
python -m venv venv
source venv/bin/activate  # Windows: venv\Scripts\activate

# Install dependencies
pip install -r requirements.txt

# Start the server
python backend/app/main.py
```

### Unity Client Setup

1. Open Unity Hub
2. Add project from `unity-client` folder
3. Open the sample scene from `Assets/Scenes/Main.scene`
4. Configure the API endpoint in the SpeechManager component

## 🛠️ Architecture

### Backend Components:
- Flask REST API
- Qwen-7B Text Generation
- Mozilla TTS Speech Synthesis
- Audio Processing Pipeline
- Emotion Analysis System

### Frontend Components:
- 3D Avatar System
- Animation Controller
- Speech Manager
- Audio Pipeline
- Network Manager

## 📚 API Documentation

### Generate Speech
```http
POST /generate
Content-Type: application/json

{
    "prompt": "Your input text here"
}
```

### Health Check
```http
GET /health
```

## 🎮 Unity Integration

The Unity client provides:
- Real-time lip-sync
- Emotional expressions
- Audio queue management
- Error handling and recovery
- Configurable animation parameters

## ⚙️ Configuration

Environment variables:
```env
FLASK_ENV=development
API_PORT=5000
MODEL_CACHE_DIR=./cache
ENABLE_GPU=true
LOG_LEVEL=INFO
```

## 🧪 Testing

```bash
# Run backend tests
pytest backend/app/tests

# Run with coverage
pytest --cov=backend/app backend/app/tests
```

## 📈 Performance Optimization

- GPU acceleration for ML models
- Audio stream optimization
- Request queuing and caching
- Memory management
- Thread pool execution

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch: `git checkout -b feature/AmazingFeature`
3. Commit your changes: `git commit -m 'Add AmazingFeature'`
4. Push to the branch: `git push origin feature/AmazingFeature`
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Anthropic for Qwen-7B model
- Mozilla TTS team
- Unity Technologies
- All contributors and supporters

## 📞 Support

For support, email: support@yourdomain.com

## 🔄 Status

![Build Status](https://your-ci-badge-url-here)
![Code Coverage](https://your-coverage-badge-url-here)
